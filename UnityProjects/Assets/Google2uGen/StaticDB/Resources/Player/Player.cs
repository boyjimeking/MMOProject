//----------------------------------------------
//    Google2u: Google Doc Unity integration
//         Copyright © 2015 Litteratus
//
//        This file has been auto-generated
//              Do not manually edit
//----------------------------------------------

using UnityEngine;
using System.Globalization;

namespace Google2u
{
	[System.Serializable]
	public class PlayerRow : IGoogle2uRow
	{
		public string _Name;
		public string _Path;
		public int _HP;
		public float _Attack;
		public float _Speed;
		public float _Size;
		public PlayerRow(string __ID, string __Name, string __Path, string __HP, string __Attack, string __Speed, string __Size) 
		{
			_Name = __Name.Trim();
			_Path = __Path.Trim();
			{
			int res;
				if(int.TryParse(__HP, NumberStyles.Any, CultureInfo.InvariantCulture, out res))
					_HP = res;
				else
					Debug.LogError("Failed To Convert _HP string: "+ __HP +" to int");
			}
			{
			float res;
				if(float.TryParse(__Attack, NumberStyles.Any, CultureInfo.InvariantCulture, out res))
					_Attack = res;
				else
					Debug.LogError("Failed To Convert _Attack string: "+ __Attack +" to float");
			}
			{
			float res;
				if(float.TryParse(__Speed, NumberStyles.Any, CultureInfo.InvariantCulture, out res))
					_Speed = res;
				else
					Debug.LogError("Failed To Convert _Speed string: "+ __Speed +" to float");
			}
			{
			float res;
				if(float.TryParse(__Size, NumberStyles.Any, CultureInfo.InvariantCulture, out res))
					_Size = res;
				else
					Debug.LogError("Failed To Convert _Size string: "+ __Size +" to float");
			}
		}

		public int Length { get { return 6; } }

		public string this[int i]
		{
		    get
		    {
		        return GetStringDataByIndex(i);
		    }
		}

		public string GetStringDataByIndex( int index )
		{
			string ret = System.String.Empty;
			switch( index )
			{
				case 0:
					ret = _Name.ToString();
					break;
				case 1:
					ret = _Path.ToString();
					break;
				case 2:
					ret = _HP.ToString();
					break;
				case 3:
					ret = _Attack.ToString();
					break;
				case 4:
					ret = _Speed.ToString();
					break;
				case 5:
					ret = _Size.ToString();
					break;
			}

			return ret;
		}

		public string GetStringData( string colID )
		{
			var ret = System.String.Empty;
			switch( colID )
			{
				case "Name":
					ret = _Name.ToString();
					break;
				case "Path":
					ret = _Path.ToString();
					break;
				case "HP":
					ret = _HP.ToString();
					break;
				case "Attack":
					ret = _Attack.ToString();
					break;
				case "Speed":
					ret = _Speed.ToString();
					break;
				case "Size":
					ret = _Size.ToString();
					break;
			}

			return ret;
		}
		public override string ToString()
		{
			string ret = System.String.Empty;
			ret += "{" + "Name" + " : " + _Name.ToString() + "} ";
			ret += "{" + "Path" + " : " + _Path.ToString() + "} ";
			ret += "{" + "HP" + " : " + _HP.ToString() + "} ";
			ret += "{" + "Attack" + " : " + _Attack.ToString() + "} ";
			ret += "{" + "Speed" + " : " + _Speed.ToString() + "} ";
			ret += "{" + "Size" + " : " + _Size.ToString() + "} ";
			return ret;
		}
	}
	public sealed class Player : IGoogle2uDB
	{
		public enum rowIds {
			chr0001
		};
		public string [] rowNames = {
			"chr0001"
		};
		public System.Collections.Generic.List<PlayerRow> Rows = new System.Collections.Generic.List<PlayerRow>();

		public static Player Instance
		{
			get { return NestedPlayer.instance; }
		}

		private class NestedPlayer
		{
			static NestedPlayer() { }
			internal static readonly Player instance = new Player();
		}

		private Player()
		{
			Rows.Add( new PlayerRow("chr0001", "TestPlayer", "chr0001", "10", "1", "5", "1"));
		}
		public IGoogle2uRow GetGenRow(string in_RowString)
		{
			IGoogle2uRow ret = null;
			try
			{
				ret = Rows[(int)System.Enum.Parse(typeof(rowIds), in_RowString)];
			}
			catch(System.ArgumentException) {
				Debug.LogError( in_RowString + " is not a member of the rowIds enumeration.");
			}
			return ret;
		}
		public IGoogle2uRow GetGenRow(rowIds in_RowID)
		{
			IGoogle2uRow ret = null;
			try
			{
				ret = Rows[(int)in_RowID];
			}
			catch( System.Collections.Generic.KeyNotFoundException ex )
			{
				Debug.LogError( in_RowID + " not found: " + ex.Message );
			}
			return ret;
		}
		public PlayerRow GetRow(rowIds in_RowID)
		{
			PlayerRow ret = null;
			try
			{
				ret = Rows[(int)in_RowID];
			}
			catch( System.Collections.Generic.KeyNotFoundException ex )
			{
				Debug.LogError( in_RowID + " not found: " + ex.Message );
			}
			return ret;
		}
		public PlayerRow GetRow(string in_RowString)
		{
			PlayerRow ret = null;
			try
			{
				ret = Rows[(int)System.Enum.Parse(typeof(rowIds), in_RowString)];
			}
			catch(System.ArgumentException) {
				Debug.LogError( in_RowString + " is not a member of the rowIds enumeration.");
			}
			return ret;
		}

	}

}
