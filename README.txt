Gold Badge League is a a collection of console application challenges written in C#. The purpose of which is to display my current understanding of the language. The collection is intended to grow to further demonstrate my progress as time develops. As of 10/6/2020: 3 challenges have been completed.

The projects were themed based upon the Pokemon universe because at the start of project 1 (before I understood the value of naming conventions) I thought that would be a wonderful idea. Below is a list of project files and their associations. 

Project 1: BerryCafe
	Main Folder: BerryCafe

		1) MenuItem: a listing of properties for the objects that populate an a fictional menu for a cafe that sells berries (an popular in-game produce for the Pokemon universe)
		2) MenuItemRepo: a list of MenuItems, as well as some methods necessary for the UI.
		3)BerryMenuUI: the interface for the fictional manager of the cafe that allows them to add existing items to the menu, remove existing items, and see existing items.
 
	Tests Folder: BerryCafeTests

Project 2: PokeSurance
	Main Folder: PokeSurance
		1)PokeClaims: a listing of properties for the objects that populate a fictional insurance agents claims database. Incorporated Enum and DateTime as property types to increase the difficulty of the challenge. 
		2)PokeClaimsRepo: as previously, is a listing of class above and contains methods used in UI, however it is also where I instantiate a queue to add complexity to the code. 
		3)PokeSuranceUI: the interface for a fictional insurance agent where they are able to see existing claims, choose whether they wish to handle an existing claim that is currently next in queue, or enter a new claim to the end of queue. 
	Tests Folder: PokeSurance_Tests

Project 3: GymLeaderBadgeEditor (aka the challenge that inspired a theme)
	Main Folder: GymLeaderBadgeEditor
		1) Badge: same as above, challenge this time is to incorporate a list of items that is populated via dictionary as a property type. This challenge is purely academic as the code would have been much cleaner and simpler either without the dictionary or without the object class. It was intended to be difficult to work around. 
		2) BadgeRepo: Holds the dictionary and some methods. 
		3) BadgeEditorUI: the interface for a fictional member of the Pokemon League Committee which allows them to alter which pokemon the gym leader of a given city has access to while testing challenges. Unlike previous lists, this one starts unpopulated. I did this because with all the various game generations, it would have been unfeasible to program in options for each one. Although, it is likely to appear as a future challenge.
	Tests Folder: BadgeTests




