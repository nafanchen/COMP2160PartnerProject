# COMP2160  - Game Development Task 2

Group: *gdt2-c*

*REFER TO WORD DOC FOR FULL REPORT DOCUMENTATION*

| Name | Student Number | 
| Nathan Chen | 45956146 | 
| Joshua Lukas | 47712651 |

This document may include images. To insert an image into your documentation, place it in the "Images" subfolder, then place the below text where you want the image to appear:

```
![Place any alt text here](Images/<IMAGE NAME AND FILE EXTENSION>)
```

Example:

![This is the alt text for an image!](Images/exampleImage.png)

## Features implemented 

| Feature             | Requirements                    |  %  | Complete (YES / NO) |
| ------------------- | ------------------------------- | --- | ------------------- | 
| Levels              | Level 1                         |  2  |         YES         |
|                     | Level 2                         |  2  |         YES         |
|                     | Level 3                         |  2  |         YES         |
| Horizontal Movement | Movement with WASD / arrow keys |  2  |         YES         |
|                     | Turning with mouse              |  2  |         YES         |
|                     | Collisions                      |  2  |         YES         |
| Vertical Movement   | Falling                         |  2  |         YES         |
|                     | Jumping                         |  2  |         YES         |
|                     | Coyote time                     |  2  |         YES         |
|                     | Jump buffer                     |  2  |         YES         |
| Controller support  | Movement                        |  1  |         YES         |
|                     | Turning avatar                  |  2  |         YES         |
|                     | Jump                            |  1  |         YES         |
|                     | Camera pitch                    |  2  |         YES         |
|                     | Camera dolly                    |  2  |         YES         |
| Camera              | Third person camera             |  2  |         YES         |
|                     | Pitch control                   |  2  |         YES         |
|                     | Dolly control                   |  2  |         YES         |
|                     | Saving between levels           |  3  |         NO          |
|                     | Lag                             |  3  |         NO          |
| Goals & Death       | Goals                           |  3  |         YES         |
|                     | Death zones                     |  3  |         YES         |
| Level Features      | Launch pads                     |  3  |         YES         |
|                     | Boost pads                      |  3  |         YES         |
| In-Game UI          | Custom font                     |  1  |         YES         |
|                     | Countdown                       |  3  |         YES         |
|                     | Timer                           |  3  |         YES         |
| Level Selection     | Selection UI                    |  2  |         YES         |
|                     | Scene Loading                   |  2  |         YES         |
| High scores         | Updating scores                 |  2  |         YES         |
|                     | Saving between levels           |  2  |         YES         |
| Debug Gizmos        | Collision points & normals      |  3  |         YES         |
|                     | Jump points                     |  3  |         YES         |
|                     | Avatar path                     |  3  |         YES         |
| WebGL build         | Working build on itch           |  4  |         YES         |            

## 1. Entity Relationship Diagram (5%)

Please include an ERD for your designed software architecture for the game, following the guidelines and examples in the lectures. Make sure all elements of your ERD are legible. Marks will be deducted for unreadable diagrams.

Your diagram should match your code as much as possible, however you can indicate unimplemented elements with a dotted line border as shown below:

![Example ERD shows two elements labelled "Complete" and "Incomplete". The complete element has a solid border; the incomplete element has a dotted border.](Images/exampleERD.png)

## 2. Project Managment (5%)

Complete the table below indicating which tasks have been assigned to each team member and whether it was completed. Two example tasks have been given.

| Task | Assigned To | Completed On  |
| ---- | ----------- | ------------- | 
| *Clone the template Git Repo* | *Student Name* | Oct 9 |
| *Create Unity project* | *Student Name* | *Incomplete* |

Tasks may include:
* Designing the code architecture
* Developing code for specific features or components
* Conducting QA
* Writing documentation
* Other important development or production tasks

Note that both team members are expected to contribute to both the writing of code and the documentation, as a key learning-outcome of this assignment is to practice managing a multi-developer project. 

You should commit and push a version of this report *at least one week* before the final deadline containing a draft task assisngment. This can be updated in your final submission.

### 2.1 Rationale

Provide a brief (~100 word) rationale for why you have allocated tasks in this fashion.

### 2.2 Version Control

Provide a brief (~100 word) outline of the version control workflow you used.


## 3. Quality Assurance (QA) Plan (5%) 

Choose two of the high-level features that you have implemented (e.g. *2. Horizontal Movement* and *5. Camera*) and write complete the QA Plan template below indicating how you would test each of these features.

| Test ID | Requirement | Test Scene | Task | Expected result |
| --------| ------------| -----------| ---- | --------------- |
|         |             |            |      |                 |

Note: The *Test Scene* column should refer to specific Unity scenes in your project, specifically designed for QA Testing of individual features (i.e. not your the three levels included in your final game).

## 4. Data Management Plan (5%)

Imagine a scenario in which you plan to publish this game on Steam. You are deciding what analytics to include in the game. Your designers want to gather playtesting analytics to assess the appeal and difficulty of the game. Your marketing team want user data to be able to better assess the market niche for the game and direct market the game to players who like similar games.

The data you plan to gather includes the following.

For every time the game is played:

| Question | Data Source |
| -------- | ----------- |
| Who is playing the game? | The system user name given by the C# property [Environment.UserName](https://learn.microsoft.com/en-us/dotnet/api/system.environment.username?view=net-7.0) |
| Who is playing the game? | The player’s Steam Persona name via the [Steamworks API](https://partner.steamgames.com/doc/api/ISteamFriends#GetPersonaName) |
| What machine is the game being played on? | The IP address of the computer given by the C# method [Dns.GetHostEntry](https://learn.microsoft.com/en-us/dotnet/api/system.net.dns.gethostentry?view=net-5.0) |
| When did the player start the game? | The date & time given by given by the C# property [DateTime.Now](https://learn.microsoft.com/en-us/dotnet/api/system.datetime.now?view=net-5.0) |
| When did the player quit the game? | The date & time given by given by the C# property [DateTime.Now](https://learn.microsoft.com/en-us/dotnet/api/system.datetime.now?view=net-5.0) |
| What other games do they enjoy? | The list of games owned by the player. via the [Steamworks API](https://partner.steamgames.com/doc/webapi/IPlayerService) |
| Who else might like this game? | The Steam ID & names of the players friends, via the [Steamworks API](https://partner.steamgames.com/doc/api/ISteamFriends) |

For every level that the player attempts:

| Question | Data Source |
| -------- | ----------- |
| What path did they take? | A sample of the avatar position taken once per second |

For the sake of this DMP, assume you have published the game on Steam and are retrieving this data from multiple users who have bought your game and signed an appropriate End User License Agreement consenting to this data gathering. Data is being gathered via the [Unity Analytics service](https://docs.unity.com/ugs/manual/analytics/manual/overview).

Complete the following Data Management Plan questions as it pertains to this project. Consider the sensitivity of the data you are collecting, and how this influences your storage and potential usage. Refer to the ACS Code of Professional Ethics, Australian Privacy Act 1988, and the GDPR where necessary.

### 4.1    Data storage and disposal 

#### 4.1.1 Data storage and location
Document where the data will be stored and what system/s will manage the data. This information should include:
* storage locations both internal and external
* how data will be accessed over time and the systems used
* back-up and recovery plan details or a link to your internal documentation.

#### 4.1.2 Data disposal (keep, destroy or transfer data)
How will you destroy data if necessary?

#### 4.1.3 Privacy
Summarise the privacy implications of data created, collected or published. Refer to the lecture notes for some hints.

Information may include:
* listing key data that contains private and sensitive information (if any)
* listing key data that is identifiable – where an individual’s identity can be reasonably ascertained.

#### 4.1.4   Ethics
Consider any ethical issues not covered elsewhere in the DMP. Refer back to the ACS Code of Ethics.
 
### 4.2 Using Data

#### 4.2.1   Data Analysis
How will the data be analysed? How will you represent the data and compare different data points with one another?

#### 4.2.2   Data Implementation
How will the data be used to improve the game? What changes might occur based on using this data to the game’s design, code base, etc.?

#### 4.2.3   Data publication
Will the data be published? Information here may include:
* Publishing locations such as online blogs, social media.
* Planned showcases of the data at conferences, meetings or other venues.

#### 4.2.4   Data sharing
Document any parties that you may share the data with, such as other game developers, advertisers, etc., and any expected challenges or identified risks with this sharing. 

## Third Party Assets used

Please indicate any third party assets used in your project including the details below

| Asset Name | Author | URL | License |
| ---------- | ------ | --- | ------- | 
|            |        |     |         |
 
## Generative AI Use Acknowledgement

Use the below table to indicate any Generative AI or writing assistance tools used in creating your document. Please be honest and thorough in your reporting, as this will allow us to give you the marks you have earnt. Place any drafts or other evidence inside this repository. This form and related evidence do not count to your word count.
An example has been included. Please replace this with any actual tools, and add more as necessary.


### Tool Used: ChatGPT
**Nature of Use** Finding relevant design theory.

**Evidence Attached?** Screenshot of ChatGPT conversation included in the folder "GenAI" in this repo.

**Additional Notes:** I used ChatGPT to try and find some more relevant design theory that I could apply to my game. After googling them, however, I found most of them were inaccurate, and some didn't exist. One theory mentioned, however, was useful, and I've incorporated it into my work.

### Tool Used: Example
**Nature of Use** Example Text

**Evidence Attached?** Example Text

**Additional Notes:** Example Text


