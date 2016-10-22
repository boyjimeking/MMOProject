using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using WebSocketSharp;
using WebSocketSharp.Net;

public class NetworkTest : MonoBehaviour 
{
	User _testUser;
	WebSocket _ws;

	void Awake () 
	{
		//StartCoroutine (Get());
		StartCoroutine (UserCreatePost());
	}

	void Update()
	{
		if (Input.GetKeyUp("s"))
		{
			string subscribe = JsonUtility.ToJson (new Subscribe(), false);
			_ws.Send(subscribe);
		}

		if (Input.GetKeyUp("t"))
		{
			string auth = JsonUtility.ToJson (new Auth(_testUser), false);
			_ws.Send(auth);
		}

		if (Input.GetKeyUp("m"))
		{
			string move = JsonUtility.ToJson (new Move(new MoveData()), false);
			_ws.Send(move);
		}
	}

	IEnumerator GetTest()
	{
		string url = "http://ec2-54-250-144-197.ap-northeast-1.compute.amazonaws.com:3000/status";
		WWW www = new WWW(url);
		yield return www;
		if (www.error == null) {
			Debug.Log(www.text);
		}
	}

	IEnumerator UserCreatePost()
	{
		string url = "http://ec2-54-250-144-197.ap-northeast-1.compute.amazonaws.com:3000/users";
		WWWForm form = new WWWForm();
		string name = "test" + Random.Range (0, 1000);
		form.AddField("name", name);
		WWW www = new WWW(url, form);
		yield return www;
		if (www.error == null) {
			//Debug.Log(www.text);
			var json = www.text;
			_testUser = JsonUtility.FromJson(json, typeof(User)) as User;
			Debug.LogFormat("id = {0}", _testUser.id);
			Debug.LogFormat("name = {0}", _testUser.name);
			Debug.LogFormat("token = {0}", _testUser.token);
		}
		ConnectWebSocket ();
	}

	void ConnectWebSocket()
	{
		_ws = new WebSocket("ws://ec2-54-250-144-197.ap-northeast-1.compute.amazonaws.com:3000/cable");

		_ws.OnOpen += (sender, e) =>
		{
			Debug.Log("WebSocket Open");
		};

		_ws.OnMessage += (sender, e) =>
		{
			Debug.Log("WebSocket Message Data: " + e.Data);
		};

		_ws.OnError += (sender, e) =>
		{
			Debug.Log("WebSocket Error Message: " + e.Message);
		};

		_ws.OnClose += (sender, e) =>
		{
			Debug.Log("WebSocket Close");
		};

		_ws.Connect();
	}

	void OnDestroy()
	{
		_ws.Close();
		_ws = null;
	}
		
	class User
	{
		public int id;
		public string name;
		public string token;
	}

	class Channel
	{
		public string channel = "DungeonChannel";
	}

	class Subscribe
	{
		public string command = "subscribe";
		public string identifier = JsonUtility.ToJson(new Channel(), false);
	}

	class AuthData
	{
		public string action;
		public int id;
		public string token;
	}

	class Auth
	{
		public string command;
		public string identifier;
		public string data;

		public Auth(User user)
		{
			command = "message";
			identifier = JsonUtility.ToJson(new Channel(), false);
			var authdata = new AuthData()
			{
				action = "auth",
				id = user.id,
				token = user.token
			};
			data = JsonUtility.ToJson(authdata, false);
		}
	}

	class MoveData
	{
		public string action = "move";
		public float x;
		public float y;
		public float pos_x;
		public float pos_y;

		public MoveData()
		{
			x = Random.Range(-1f, 1f);
			y = Random.Range(-1f, 1f);
			pos_x = Random.Range(-1f, 1f);
			pos_y = Random.Range(-1f, 1f);
		}
	}

	class Move
	{
		public string command;
		public string identifier;
		public string data;

		public Move(MoveData movedata)
		{
			command = "message";
			identifier = JsonUtility.ToJson(new Channel(), false);
			data = JsonUtility.ToJson(movedata, false);
		}
	}
}