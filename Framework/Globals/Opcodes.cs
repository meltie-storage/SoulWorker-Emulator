// Licensed under the MIT license. See LICENSE file in the project root folder for full license information.

namespace SoulWorker.Framework.Globals
{
    class Opcodes
    {
        //receive_eSUB_CMD_LOGIN_RESULT = 0x00,				  	    //(int a1@<ecx>, int a2@<edi>, int a3@<esi>, int a4);
		//receive_eSUB_CMD_ENTER_SERVER = 0x01,				  	    //(void *this, int a2);
		//receive_eSUB_CMD_ENTER_SERVER_RES = 0x02,			 	    //(int a1@<ecx>, int a2@<edi>, int a3@<esi>, int a4);
		//receive_eSUB_CMD_MOBILE_AUTH = 0x03,				  	    //(void *this, int a2);
		//receive_eSUB_CMD_ENTER_WAIT_CHECK = 0x04,			  	    //(void *this, int a2);
		//receive_eSUB_CMD_OPTION_LOAD = 0x05,				  	    //(int a1@<edi>, int a2@<esi>, int a3);
		//receive_eSUB_CMD_DELETE_CHARACATER_RES = 0x06,		    //(void *this, int a2);
		//receive_eSUB_CMD_CHARACTER_LIST_RES = 0x07,			    //(void *this, int a2);
		//receive_eSUB_CMD_SELECT_CHARACTER_RES = 0x08,		  	    //(void *this, int a2);
		//receive_eSUB_CMD_CHARACTER_ENTER_PROLOGUE = 0x09,		    //(void *this, int a2);
		//receive_eSUB_CMD_CHARACTER_ENTER_BATTLE_ZONE = 0xA,       //(void *this, int a2);
		//receive_eSUB_CMD_SECOND_PASSWORD = 0xB,			        //(int a1@<ecx>, int a2@<edi>, int a3@<esi>, int a4);
		//receive_eSUB_CMD_TRADE_PASSWORD	= 0xC,			        //(int a1@<ecx>, int a2@<edi>, int a3@<esi>, int a4);
		//receive_eSUB_CMD_CHARACTER_CHECK_NAME = 0xD,			    //(void *this, int a2);
		//receive_eSUB_CMD_CHARACTER_LOAD_DISTRICT_STATE = 0xE,	    //(void *this, int a2);
		//receive_eSUB_CMD_CHARACTER_LOAD_MAZE_STATE = 0xF,		    //(void *this);
		//receive_eSUB_CMD_ENTER_MAZE_LIMIT_COUNT_LOAD = 0x10,	    //(void *this, int a2);
		//receive_eSUB_CMD_ENTER_MAZE_LIMIT_COUNT_LOAD2 = 0x11,	    //(int a1); // This opcode needs to be verified!
		//receive_eSUB_CMD_ENTER_GAMESERVER_RES	= 0x11,			    //(int this, int a2);
		//receive_eSUB_CMD_CHARACTER_DB_LOAD_SYNC = 0x12,	        //(int a1@<ecx>, int a2@<edi>, int a3@<esi>, int a4);
		
		//LoginScene::receive_eSUB_CMD_CHARACTER = 0x13,	        //(void *this, int a2);
		//LoginScene::DoUpdateScene = 0x14,						    //(void *this, int a2); GetRecvShutDownMessage() -> g_spApp->Quit()
		//LoginScene::receive_eSUB_CMD_CHARACTER_KICK_OUT = 0x15,	//(void *this, int a2);
		
		// Placeholder
    }
}
