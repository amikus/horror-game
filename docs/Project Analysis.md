# Project Analysis
### Analysis of development process, completed after project's final build.

## Project Overview

For our project, we intended to create a three-dimensional video game in the first-person-shooter and horror genres. We created our game in Unity 5 using C# as our scripting language. Our game is wrapped in a menu system which allows multiple game modes to be selected, and win conditions for each game mode are present, as well as Victory and Game Over screens after the game is complete.

## Testing Efforts

Testing a Unity project turned out to be more difficult than we anticipated, and this was one of the most difficult parts of this project for our team. Because the majority of a Unity project is composed of game objects (as opposed to accessible code), it was difficult for us to determine what should be tested. Consequently, much of our testing for this project was done manually. This testing was time-consuming and it was difficult to make our manual tests exhaustive. Each manual test had to be focused on verifying that a particular aspect of the game worked as intended.

We eventually used an add-on for Unity called Unity Test Tools, and this tool allowed us to attach assertions to Unity game objects. This allowed us to add a number of unit-style tests to our project in the form of assertions. These tests were used to verify that various game objects and assets were loading when expected and behaving as anticipated.

## Project Management 

After a few intial meetings, we defined a broad outline of our project in several initial documents (detailed below), and we used these documents to guide our development process.

The majority of our work took place in the Unity 5 game development IDE, and we used Git (with Github) to keep track of our code. We tried several communication tools before eventually settling on Slack, which worked very well for us. The majority of our team coordination occurred in Slack or during face-to-face meetings.

#### Project Management-Related Documentation

* [Project Proposal](https://github.com/amikus/horror-game/blob/master/docs/Project%20Proposal.md) - This contains a broad description of our original project goals and anticipated features. We did not update this document after it was originally created.
* [Organizational Structure](https://github.com/amikus/horror-game/blob/master/docs/Organizational%20Structure.md) - Here we defined the anticipated division of labor among our team members. We did not update this documents after it was originally created.
* [Goals](https://github.com/amikus/horror-game/blob/master/docs/Goals.md) - This contains a detailed breakdown of each task that we thought would need to be accomplished to create our project, as well as estimates of how long we expected each task to take (in Scrum-like points). This was a "living" document, and we updated it on a regular basis, indicating when tasks had begun and when they had been completed. This document guided our development process, as it reminded us of our initial plans and kept us from wandering too far away from them. While we did not remove any of our initial goals from the document (even uncompleted goals), we did occassionally add additional items to our list.
* [Estimations](https://github.com/amikus/horror-game/blob/master/docs/Estimations.md) - This document contains our original point-based estimates from our Goals document, but also includes estimates of the actual time that it took us to complete each task. This allowed us to see how accurate our original estimates had been when we completed the project.
* [Testing](https://github.com/amikus/horror-game/blob/master/docs/Testing.md)  - This document allowed us to keep track of our unit, manual, and integration tests.

#### Tools/Languages Used
Unity 5
Unity Asset Store
Unity Test Tools/Languages
Git, with repos hosted by Github
C#
Slack

#### Tools/Languages Attempted but Abandoned
Trello
JavaScript
What's App

#### Reference Materials
Artificial Intelligence for Games, by Ian Millington and John Funge
Unity 4.x Game AI Programming, by Aung Sithu Kyaw, Clifford Peters, and Thet Naing Swe
Unity's website
YouTube
Stack Overflow
Atlassian's git tutorials
Github
Various other websites

## What We Learned

* Technologies - We learned a tremendous amount about Unity, game development, and Git during this project.
* Coordination/Teamwork - We also learned a lot about how to coordinate with multiple people to complete a software project. We had to distribute the project among four people with different schedules and lives, and we did a lot of our development from geographically distributed locations, so we did not have the advantages that full-time developers often have when they work in the same office. We were all intially strangers to each other, but we managed to settle on an idea fairly quickly and stay on task. At times, our code would conflict, and we would accidentally over-write someone else's work, but we managed to stay positive and work together to resolve these conflicts. Having multiple people working on the project meant that we could really zero-in on our own task. It was extremely satisfying to see the entire project moving forwards even though we were each only working on one or two components at a time.
* Distribution of Time - One of the biggest surprises was that the majority of our time working on this project was spent discussing the project in person, communicating online, researching and learning, debugging, writing documentation, and wrestling with issues related to the Git repository and its interactions with Unity. At times, it felt like only  10% of the project was spent actually writing new code and developing new game features. 
* Learning Curve - We learned that when a team is learning new technologies, the project can move in fits and starts, and that each new competency can create dissatisfaction with earlier work that was believed to be completed. Work that seemed "good enough" at the beginning of the project was often reworked several times. Our skills were so much better developed by the end of the project that it feels like if we made a new project today with the same goals and tools, we would be able to produce a game in half the time that was twice as professional and had twice as many features.

## Room for Improvement

* AI - The AI and pathing of the characters in the game could be greatly improved.
* Testing - Our testing could be greatly expanded.
* Cohesive Style - Because we were relying on publically available and free assets, our game does not have a unified style in terms of environment, sounds, enemies, or objects. Our Heads-Up Display/GUI would also benefit from a more unified design.
* Diversity of Enemies - Only two enemy types were used in the game, as it was difficult to find publically available, free assets that were well-made and fit within the 3-D horror and shooter genres.
* Diversity of Weapons - Only a few weapons were included in this game.
* Improvement of Spawn Locations - The spawn locations in this game were determined intuitively and not based on any mathematical analysis of the number of creatures likely to appear in any given area or the likely overlap between spawn points.
* Game Environment - The game world is relatively sparse when compared with modern games. The inclusion of additional assets could enhance the appearance and immersiveness of the game. 
