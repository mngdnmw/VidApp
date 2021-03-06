﻿using System;
using System.Collections.Generic;
using VidAppBLL;
using VidAppBLL.BusinessObjects;

namespace VidAppUI
{
    class MainClass
    {
        static BLLFacade bllFac = new BLLFacade();

        public static void Main(string[] args)
        {

            Introduction();

            var vid1 = new VideoBO()
            {
                Name = "Movie",
                Director = "This guy",
                Duration = 12312
            };

            var vid2 = new VideoBO()
            {
                Name = "Movie2",
                Director = "This guy2",
                Duration = 12312
            };

            //Use of method to get the service
            //bllFac.GetVidService().Create(vid1);

            //Use of property - more widely used in .Net, so will use this one 
            bllFac.VidService.Create(vid2);

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
                Console.WriteLine($"ID: {video.Id} Name: {video.Name} Director: {video.Director} Duration: {video.DurationInString}");
            else
                Console.WriteLine($"That video ID does not exist");
        }

        private static void EditVideo()
        {
            var videoFound = FindVidByID();
            if (videoFound != null)
            {
                Console.WriteLine("Name: ");
                videoFound.Name = Console.ReadLine();
                Console.WriteLine("Director: ");
                videoFound.Director = Console.ReadLine();
                Console.WriteLine("Duration(minutes): ");
                int duration;
				while (!int.TryParse(Console.ReadLine(), out duration))
				{
					Console.WriteLine("Please insert a number");
				}
                Console.WriteLine("Video edited!");

                bllFac.VidService.Update(videoFound);
            }
            else
                Console.WriteLine("Video not found");
        }

        private static void DeleteVideo()
        {

            var videoFound = FindVidByID();
            if (videoFound != null)
            {
                bllFac.VidService.Delete(videoFound.Id);
            }

            //Use of turnary - if the videoFound is null then it will do the thing straight after the question mark
            var response = videoFound == null ? "Video not found" : "Video deleted";
            Console.WriteLine(response);
        }

        private static VideoBO FindVidByID()
        {
            Console.WriteLine("Insert video ID: ");

            int id;
            while (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Please insert a number");
            }

            return bllFac.VidService.Get(id);

        }

        private static void AddVideo()
        {


            Console.WriteLine("Name: ");
            var name = Console.ReadLine();
            Console.WriteLine("Director: ");
            var director = Console.ReadLine();
			int duration;
			while (!int.TryParse(Console.ReadLine(), out duration))
			{
				Console.WriteLine("Please insert a number");
			}
            Console.WriteLine("Video successfully added!");
            bllFac.VidService.Create(new VideoBO()
            {
                Name = name,
                Director = director,
                Duration = duration
            });

        }

        private static void ReadAllVideos()
        {
            Console.WriteLine("List of movies");
            foreach (var video in bllFac.VidService.GetAll())
            {
                Console.WriteLine($"ID: {video.Id} Name: {video.Name} Director: {video.Director} Duration: {video.DurationInString}");
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
