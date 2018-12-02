﻿using UnityEngine;

// supress 'warning CS0414: The private field `[BLANK]' is assigned but its value is never used' messages
//   as they are assigned/read when constructing/parsing JSON messages with JsonUtility.ToJson()/JsonUtility.FromJson<>()
#pragma warning disable 0414

namespace NetworkDefinitions
{
	[System.Serializable]
	public abstract class GameData
	{
	}

	namespace Request
	{
		[System.Serializable]
		public class JoinSession
		{
			[SerializeField]
		    private string command = "joinSession";
		    public string Command
		    {
		    	get
		    	{
		    		return command;
		    	}
		    }

			// valid sessions 0-Int32.MaxValue; -1 = last available session
			[SerializeField]
		    private int sessionID = int.MinValue;
		    public int SessionID
		    {
		    	get
		    	{
		    		return sessionID;
		    	}
		    }

		    // without an explicit sessionID specified, join the last available session
		    public JoinSession(int sessionID = -1)
		    {
				this.sessionID = sessionID;
		    }
		}

		[System.Serializable]
		public class CreateSession<CustomGameData> where CustomGameData : NetworkDefinitions.GameData
		{
			[SerializeField]
		    private string command = "createSession";
		    public string Command
		    {
		    	get
		    	{
		    		return command;
		    	}
		    }
			[SerializeField]
		    private CustomGameData parameters;
		    public CustomGameData Parameters
		    {
		    	get
		    	{
		    		return parameters;
		    	}
		    }

		    public CreateSession(CustomGameData parameters)
		    {
		    	this.parameters = parameters;
		    }
		}

		[System.Serializable]
		public class UpdateSession<CustomGameData> where CustomGameData : NetworkDefinitions.GameData
		{
			[SerializeField]
		    private string command = "updateSession";
		    public string Command
		    {
		    	get
		    	{
		    		return command;
		    	}
		    }
			[SerializeField]
		    private int sessionID = int.MinValue;
		    public int SessionID
		    {
		    	get
		    	{
		    		return sessionID;
		    	}
		    }
			[SerializeField]
		    private CustomGameData parameters;
		    public CustomGameData Parameters
		    {
		    	get
		    	{
		    		return parameters;
		    	}
		    }

		    // without an explicit sessionID specified, join the last available session
		    public UpdateSession(int sessionID, CustomGameData parameters)
		    {
		    	this.sessionID = sessionID;
		    	this.parameters = parameters;
		    }
		}
	}

	namespace Response
	{
		[System.Serializable]
		public class SessionJoin<CustomGameData> where CustomGameData : NetworkDefinitions.GameData
		{
			[SerializeField]
		    private string command = "";
		    public string Command
		    {
		    	get
		    	{
		    		return command;
		    	}
		    }

			[SerializeField]
		    private int sessionID;
		    public int SessionID
		    {
		    	get 
		    	{
		    		return sessionID;
		    	}
		    }
			[SerializeField]
		    private CustomGameData session;
		    public CustomGameData Session
		    {
		    	get
		    	{
		    		return session;
		    	}
		    }

		    private SessionJoin()
		    {
		    }

		    public bool IsValid
		    {
		    	get
		    	{
			    	if(command != "sessionJoin") return false;
			    	if(sessionID == -1) return false;
			    	return true;
		    	}
		    }
		}

		[System.Serializable]
		public class SessionUpdate<CustomGameData> where CustomGameData : NetworkDefinitions.GameData
		{
			[SerializeField]
		    private string command = "";
		    public string Command
		    {
		    	get
		    	{
		    		return command;
		    	}
		    }

			[SerializeField]
		    private int sessionID;
		    public int SessionID
		    {
		    	get 
		    	{
		    		return sessionID;
		    	}
		    }
			[SerializeField]
		    private CustomGameData session;
		    public CustomGameData Session
		    {
		    	get
		    	{
		    		return session;
		    	}
		    }

		    private SessionUpdate()
		    {
		    }

		    public bool IsValid
		    {
		    	get
		    	{
			    	if(command != "sessionUpdate") return false;
			    	if(sessionID == -1) return false;
			    	return true;
		    	}
		    }
		}
	}
}

namespace Game
{
	[System.Serializable]
	public class SessionData : NetworkDefinitions.GameData
	{
		[SerializeField]
		private float playerPositionX = -1.0f;
		public float PlayerPositionX
		{
			get
			{
				return playerPositionX;
			}
		}
		[SerializeField]
		private float playerPositionY = -1.0f;
		public float PlayerPositionY
		{
			get
			{
				return playerPositionY;
			}
		}
		[SerializeField]
		private float health = -1.0f;
		public float Health
		{
			get
			{
				return health;
			}
		}

	    public SessionData(float playerPositionX, float playerPositionY, float health)
	    {
			this.playerPositionX = playerPositionX;
			this.playerPositionY = playerPositionY;
			this.health = health;
	    }
	}
}