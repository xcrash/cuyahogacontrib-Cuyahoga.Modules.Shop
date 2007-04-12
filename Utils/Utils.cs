using System;
using System.Data;
using System.Web;
using System.Web.SessionState;
using System.ComponentModel;
using System.Collections;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.HtmlControls;

using Cuyahoga.Modules.Shop.Domain;
using Cuyahoga.Web.Util;

namespace Cuyahoga.Modules.Shop.Utils
{
	/// <summary>
	/// Summary description for Utils.
	/// </summary>
	public class Utils
	{
		public Utils()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		public string BadWordReplace(object o)
		{
			return "";
		}

		public static DataTable TimeZones() 
		{
			using(DataTable dt = new DataTable("TimeZone")) 
			{
				dt.Columns.Add("Value",Type.GetType("System.Int32"));
				dt.Columns.Add("Name",Type.GetType("System.String"));

				dt.Rows.Add(new object[]{-720,"(GMT - 12:00) Enitwetok, Kwajalien"});
				dt.Rows.Add(new object[]{-660,"(GMT - 11:00) Midway Island, Samoa"});
				dt.Rows.Add(new object[]{-600,"(GMT - 10:00) Hawaii"});
				dt.Rows.Add(new object[]{-540,"(GMT - 9:00) Alaska"});
				dt.Rows.Add(new object[]{-480,"(GMT - 8:00) Pacific Time (US & Canada)"});
				dt.Rows.Add(new object[]{-420,"(GMT - 7:00) Mountain Time (US & Canada)"});
				dt.Rows.Add(new object[]{-360,"(GMT - 6:00) Central Time (US & Canada), Mexico City"});
				dt.Rows.Add(new object[]{-300,"(GMT - 5:00) Eastern Time (US & Canada), Bogota, Lima, Quito"});
				dt.Rows.Add(new object[]{-240,"(GMT - 4:00) Atlantic Time (Canada), Caracas, La Paz"});
				dt.Rows.Add(new object[]{-210,"(GMT - 3:30) Newfoundland"});
				dt.Rows.Add(new object[]{-180,"(GMT - 3:00) Brazil, Buenos Aires, Georgetown, Falkland Is."});
				dt.Rows.Add(new object[]{-120,"(GMT - 2:00) Mid-Atlantic, Ascention Is., St Helena"});
				dt.Rows.Add(new object[]{-60,"(GMT - 1:00) Azores, Cape Verde Islands"});
				dt.Rows.Add(new object[]{0,"(GMT) Casablanca, Dublin, Edinburgh, London, Lisbon, Monrovia"});
				dt.Rows.Add(new object[]{60,"(GMT + 1:00) Berlin, Brussels, Kristiansund, Madrid, Paris, Rome"});
				dt.Rows.Add(new object[]{120,"(GMT + 2:00) Kaliningrad, South Africa, Warsaw"});
				dt.Rows.Add(new object[]{180,"(GMT + 3:00) Baghdad, Riyadh, Moscow, Nairobi"});
				dt.Rows.Add(new object[]{210,"(GMT + 3:30) Tehran"});
				dt.Rows.Add(new object[]{240,"(GMT + 4:00) Adu Dhabi, Baku, Muscat, Tbilisi"});
				dt.Rows.Add(new object[]{270,"(GMT + 4:30) Kabul"});
				dt.Rows.Add(new object[]{300,"(GMT + 5:00) Ekaterinburg, Islamabad, Karachi, Tashkent"});
				dt.Rows.Add(new object[]{330,"(GMT + 5:30) Bombay, Calcutta, Madras, New Delhi"});
				dt.Rows.Add(new object[]{360,"(GMT + 6:00) Almaty, Colomba, Dhakra"});
				dt.Rows.Add(new object[]{420,"(GMT + 7:00) Bangkok, Hanoi, Jakarta"});
				dt.Rows.Add(new object[]{480,"(GMT + 8:00) Beijing, Hong Kong, Perth, Singapore, Taipei"});
				dt.Rows.Add(new object[]{540,"(GMT + 9:00) Osaka, Sapporo, Seoul, Tokyo, Yakutsk"});
				dt.Rows.Add(new object[]{570,"(GMT + 9:30) Adelaide, Darwin"});
				dt.Rows.Add(new object[]{600,"(GMT + 10:00) Melbourne, Papua New Guinea, Sydney, Vladivostok"});
				dt.Rows.Add(new object[]{660,"(GMT + 11:00) Magadan, New Caledonia, Solomon Islands"});
				dt.Rows.Add(new object[]{720,"(GMT + 12:00) Auckland, Wellington, Fiji, Marshall Island"});
				return dt;
			}
		}
	}
}
