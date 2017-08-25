using System;
using System.Collections.Generic;
using VidAppBE;

namespace VidAppUI
{
	class MainClass
	{


		public static void Main(string[] args)
		{


			videosList.Add(new Video()
			{
				ID = id++,
				Name = "Movie",
				Director = "This guy",
				Genre = "Documentary",
			});

			Introduction();

			List<string> menuItems = new List<string> { "Create video", "Read videos", "Update video", "Delete video", "Search", "Exit" };

			var selection = 0;

			while (selection != 6)
			{
				selection = ShowMenu(menuItems);
				PrintSelection(selection);
			}

			Console.WriteLine("Hej hej!");


		}

		/// <summary>
		/// Shows the menu.
		/// </summary>
		/// <returns>The menu list</returns>
		/// <param name="menuItems">Menu items.</param>
		private static int ShowMenu(List<string> menuItems)
		{
			//Console.Clear();

			Console.WriteLine("\nSelect what you want to do:");
			for (int i = 0; i < menuItems.Count; i++)
			{
				//Less memory heavy than the + signs
				Console.WriteLine($"{ (i + 1)}:{ menuItems[i]}");
			}

			Console.WriteLine("");

			int selection;

			while (!int.TryParse(Console.ReadLine(), out selection) || selection < 1 || selection > 6)
			{
				Console.WriteLine("You need to select one of the menu items by typing in the menu item number (between 1-5)");
			}

			return selection;

		}

		private static void PrintSelection(int selection)
		{
			switch (selection)
			{
				case 1:
					AddVideo();
					break;
				case 2:
					ReadAllVideos();
					break;
				case 3:
					EditVideo();
					break;
				case 4:
					DeleteVideo();
					break;
				case 5:
					ReadVidByID();
					break;
				default:
					break;
			};

		}

		private static void ReadVidByID()
		{
			var video = FindVidByID();
			if (video != null)
				Console.WriteLine($"ID: {video.ID} Name: {video.Name} Director: {video.Director} Genre: {video.Genre}");
			else
				Console.WriteLine($"That video ID does not exist");
		}

		private static void EditVideo()
		{
			var video = FindVidByID();
			Console.WriteLine("Name: ");
			video.Name = Console.ReadLine();
			Console.WriteLine("Director: ");
			video.Director = Console.ReadLine();
			Console.WriteLine("Genre: ");
			video.Genre = Console.ReadLine();
			Console.WriteLine("Video edited!");
		}

		private static void DeleteVideo()
		{

			var video = FindVidByID();
			if (video != null)
			{
				videosList.Remove(video);
				Console.WriteLine("Video successfully deleted!");
			}

		}

		private static Video FindVidByID()
		{
			Console.WriteLine("Insert video ID: ");

			int id;
			while (!int.TryParse(Console.ReadLine(), out id))
			{
				Console.WriteLine("Please insert a number");
			}


			foreach (var video in videosList)
			{
				if (video.ID == id)
				{
					return video;
				}
			}

			return null;
		}

		private static void AddVideo()
		{


			Console.WriteLine("Name: ");
			var name = Console.ReadLine();
			Console.WriteLine("Director: ");
			var director = Console.ReadLine();
			Console.WriteLine("Genre: ");
			var genre = Console.ReadLine();
			Console.WriteLine("Video successfully added!");

			videosList.Add(new Video()
			{
				ID = id++,
				Name = name,
				Director = director,
				Genre = genre,
			});

		}

		private static void ReadAllVideos()
		{
			Console.WriteLine("List of movies");
			foreach (var video in videosList)
			{
				Console.WriteLine($"ID: {video.ID} Name: {video.Name} Director: {video.Director} Genre: {video.Genre}");
			}


		}

		//ref works similiarly to out, but it requires initialisation before use 
		private static void AddItems(ref List<string> menuItems, string item)
		{
			menuItems.Add(item);

		}

		private static void Introduction()
		{
			Console.WriteLine("Welcome to the world's best video application\xB2a \n\xB2aJust better than Jeppe's");
		}


	}
}
