// This file is automatically generated.
using System;
using System.Text;
using System.Runtime.InteropServices;
using KACAPI.Attributes;

namespace KACAPI
{

	[InterfaceVersion("SteamUser016")]
	public interface ISteamUser016
	{
		[VTableSlot(0)]
		Int32 GetHSteamUser();
		[VTableSlot(1)]
		bool BLoggedOn();
		[VTableSlot(2)]
		CSteamID GetSteamID();
	};
}