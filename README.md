# COMP2160 Game Development Task 2

**Group:** gtd2-c

**Group members:** Nathan Chen 45956146

**URL:** *your itch.io build URL (and password if necessary)*

## Topics covered:
* Physics
* Camera control
* Gizmos
* User Interface
* Scene Management
* Game Architecture
* Project Management
* Version Control
* Quality Assurance
* Data Management

## Requirements
This assignment is to be done in pairs to given you experience with collaborative development. You will work in Unity 2022.3.37f1. 

Your task is to implement a copy of this 3D third-person speed-running platformer. A completed version of this game is available to play here:    

https://wordsonplay.itch.io/comp2160-2024-gdt2

![Sample screenshot from the game](Documents/Images/Screenshot.png)
 
## Assets
For this project we recommend you use the free [Gridbox Prototype Materials](https://assetstore.unity.com/packages/2d/textures-materials/gridbox-prototype-materials-129127) from the Unity Asset Store. Note that these materials require your Unity project to use the **Universal Render Pipeline**. To do this make sure you select the **Universal 3D template** when creating your project in Unity Hub.

You are also welcome to use any of the assets from Malcolm & Cameron’s [unity utils](https://github.com/malcolmryan/unity-utils) (as used in live lectures. No other third-party code assets should be used in this assignment.

## Features
Your game should implement the following features, described in detail below. Each feature has an assigned weighting that contributes to your mark. Design decisions such as timings, movement speeds, etc. are all up to you unless specified, and should be implemented to allow change in a designer-friendly way. 

| Feature | Weighting |
| ------- | ----------|
| Levels                    |  6% | 
| Horizontal movement       |  6% |
| Vertical movement         |  8% |
| Debug gizmos              |  9% |
| Camera                    | 12% |
| Game controller support   |  8% |
| Goals & Death             |  6% |
| Level features            |  6% |
| In-game UI                |  7% |
| Level selection           |  4% |
| High scores               |  4% |
| WebGL build               |  4% |
| Documentation             | 20% |
| Total                    | 100% |

A more detailed breakdown of marks per feature is given in the documentation. Note that not all features are worth the same amount or have the same difficulty.

### 1. Level Maps (6%)
1.   You should implement three different level maps for the game (in addition to any levels you create for QA testing).
2.   Your maps should be built on a grid using the basic 3D primitives. Walls and floors should be textured using the Scalable Grid Prototype Materials provided, to clearly communicate position and scale.  
3.   Maps should clearly demonstrate the level features implemented (7 and 8 below), without being too difficult for your marker to complete).
### 2. Horizontal Movement (6%)
1.   The player avatar should be represented by a 2 x 1 x 1 block, with an appropriate collider.
2.   The avatar should move forward/back and sideways left/right (strafing) with the WASD keys and also with the arrow keys.
3.   Changes in movement speed should be instantaneous when the player presses/releases a direction key (i.e. there should be zero acceleration/deceleration time).
4.   Moving the mouse left/right should cause the avatar to rotate to the left/right. This control should be independent of screen resolution.
5.   Movement controls should apply whether the avatar is on the ground or in the air.
6.   If the avatar movement causes it to collide with a wall, it should move smoothly along the surface of the wall, without rotating the avatar. 
### 3. Vertical Movement (8%)
1.   While the avatar is in the air, it should accelerate downwards due to gravity until it reaches a designated maximum fall speed, after which it should not accelerate any further.
2.   Vertical movement should stop when the avatar touches the ground.
3.   Vertical movement should not be affected by contact with walls.
4.   If the player presses the jump button (mapped to the space key) while the avatar is on the ground, the avatar should initiate a jump, moving upwards with sufficient speed to allow it to jump up a step 1m high, but not 2m.
5.   The jump should include 0.1s of “coyote time”. I.e. if the jump button is pressed within 0.1s after leaving contact with the ground, the jump should still apply.
6.   The jump should include 0.1s of “jump buffer”. I.e. if the jump button is pressed within 0.1s before contacting the ground, the jump should still be performed when the avatar contacts the ground. 
### 4. Debug Gizmos (9%) 
1.   Debug gizmos should be drawn in the Scene view showing wire spheres at each contact point between the player avatar rigidbody and the other colliders in the scene.
2.   Each contact point should also show a line pointing in the direction of the collision normal vector.
3.   The point where the avatar was when the jump button was last pressed should be drawn as a wire sphere.
4.   A line gizmo should be drawn behind the avatar showing its position for the last ~10s of movement. 
### 5. Camera (12%)
1.   The game should play in a 16:9 aspect ratio camera.
2.   The game should include a third-person camera situated behind the player, looking downwards (by default). It should follow the player avatar.
3.   The vertical angle (pitch) of the camera should be adjustable by pressing the left mouse button and moving the mouse up and down. The camera should rotate vertically around the player, between sensible upper and lower bounds. Moving the mouse while the button is released should not affect the camera. This control should be independent of screen resolution.
4.   Rotating the mouse scroll wheel forward/back should ‘dolly’ the camera towards / away from the avatar (i.e. it should change the distance between the camera and the avatar). Sensible upper and lower bounds should be applied.
5.   These camera settings (pitch and dolly) should be retained when restarting a level or between levels.
6.   The camera movement should lag slightly behind the avatar movement, both in terms of position and rotation.
### 6. Game controller support (8%)
1.   A game-controller can be used to control avatar movement with the left stick mapped to the movement described in 2.2.
2.   The horizontal axis of the right stick can be used to control avatar rotation, as described in 2.4 above.
3.   The “south” button (the A button on an Xbox controller) can be used to cause the player  to jump as described in 3.4 above.
4.   The vertical axis of the right stick can be used to control camera pitch, when the right shoulder button is pressed, as described in 5.3 above.
5.   The up/down axis of the d-Pad can be used to control camera dolly, as described in 5.4 above.
### 7. Goals & Death (6%)
1.   Each level should include at least one green goal volume. The level is complete when the base of the avatar is entirely within this volume, and the player has won. Merely touching the volume is not sufficient.
2.   Levels should also include red death zones. When the avatar touches a death zone, the game is immediately over, and the player has lost.
3.   When the game is over due to either of these conditions, avatar movement should stop.
### 8. Level Features (6%)
1.   Launch pads are denoted by blue rectangles on the floor. When the avatar contacts a launch pad, the avatar is immediately launched vertically. Launch speed should be enough to allow the avatar to jump up a step 4m high.
2.   Boost pads are denoted by yellow rectangles on the floor. While the avatar is in contact with the pad, the avatar rapidly accelerates (over 0.1s) to a speed of 10m/s in the forward direction of the pad. This forward movement is in addition to the regular horizontal movement applied by the controls.
3.   This speed boost is maintained as long as the avatar is not touching the ground. When the avatar touches the ground (and not a boost pad) the speed boost rapidly decelerates (over 0.1s) to zero.
### 9. In-game UI (7%)
1.   All UI elements should be displayed using a custom font of your choice from the [Font Library](https://fontlibrary.org/) website. Make sure the font has a suitable license (such as the Open Font License) that allows you to use the font (and distribute the resulting game). 
2.   At the beginning of each level, a 3-second countdown should be displayed in the centre of the screen. The countdown should disappear when it reaches zero.
3.   During the countdown the avatar should not be able to move, however the camera can be adjusted. When the countdown reaches zero, the movement controls should be enabled.
4.   A timer should be displayed in one corner of the screen. This timer should be formatted as “MM:SS.HH” denoting minutes (MM), seconds (SS) and hundredths of a second (HH), with values padded on the left with zeros. So, for example, 0 minutes and 5.45 seconds should be shown as “00:05.45”.
5.   The timer should start when the countdown reaches zero and should run until the level is over (due to the goal or death).
### 10. Level selection (4%)
1.   The game should begin with a level-selection dialogue showing a level number and three buttons: Prev, Next and Play. 
2.   Pressing Prev or Next should decrease or increase the level number shown (without going past sensible maximum and minimum values).
3.   Pressing Play should start playing the selected level and hide the selection dialogue.
4.   When the level is over (due to a goal or death) the selection dialogue should show again, allowing the player to replay the same level (by default) or select another. 
### 11. High scores (4%)
1.   The last time and best (shortest) time to complete should be stored for each level. These values should be updated whenever the player wins a level.
2.   The level selection dialogue should display these scores for the currently selected level, formatted as “MM:SS.HH”, as described in 7d) above.
3.   If the level has not yet been successfully completed the word “incomplete” should be displayed instead.
4.   Last and best times should be stored between play sessions, so quitting and restarting the game will not reset their values (on a particular device).
### 12. WebGL build (4%)
1.   Make a WebGL build of your game.
2.   Create an account on [itch.io](https://itch.io/) (or use an existing account) and upload your build. Test that it is playable in both the windowed and full-screen modes.
3.   Add the URL for your build to the README.md file in your repository. 
4.   If you want to make your build private, also include the password in the README.md.

### Development Documentation (20%)
The template repo includes a Documentation folder containing a Report.md file. Edit this document to include answers to each of the questions it contains. Marks for this are awarded as indicated in the document.

### Submission
We will mark the game, code and documentation within this repository. To submit your project, make a final push of this repository with the commit message “Final Submission”. This will indicate to us you are submitting your project and are ready to be marked. No sympathy will be shown if your first commit is minutes before the deadline and something goes wrong in the process. Good version control habits are an important part of game development.
 
Make sure your GitHub account is correctly associated with your student number in GitHub Classroom. Edit this README.md file to include your name and student number at the top, so we know it is your code. Place your completed documentation as a PDF file in the “Documentation” folder in this repository.

Note: We will under no circumstances be marking code submitted to a different repository, via Google Drive, USB stick or any other method. Ensure you are working in this repository and pushing regularly.

At the end of the project, you will submit individual peer assessment reports, using the quiz provided on iLearn, to assess both your own contribution and that of your teammate. You need to provide a grade (following the rubric given in the template) and a justification for the grade. This grade will be kept private from your teammate but will be used as evidence to adjust the final individual grade weighting. Failure to submit meaningful peer assessment will result in a penalty of up to 10% to your individual grade.
 
### Project management and version control
This is a pair project but will be marked individually based on:
* Task allocation
* Contributions to the project git repository
* Peer assessment

The Report.md file in the template repo includes a Task Allocation question.

One week before the final deadline you should commit and push a draft task allocation, indicating which tasks are to be completed by each team member. 

Tasks may include:
* Designing the code architecture
* Developing code for specific features
* Conducting QA
* Writing documentation
* Other important development or production tasks

Note that both team members are expected to contribute to both the writing of code and the documentation, as a key learning-outcome of this assignment is to practice managing a multi-developer project. 

Amendments can be made to this document to indicate which tasks were completed by each team member in the final submission, including any additional tasks that were added after the original submission.

You are expected to use the branching workflow described in lectures for your repository. Your repo should include a main branch for stable feature releases (after testing is completed) and separate develop branches to contain features under development. 

You are expected to use the prefab-based scene construction described in lectures to break the scene into separate components to avoid merge conflicts.
 
### Marking
Implementation of the game features above makes up 80% of your grade. The rubric used to mark each feature will be:

#### Correctness (50%) per feature attempted

| Grade |  Criteria |
| ----- | --------- |
| HD (100) | Code is free from any apparent errors, and problems are solved using suitable programming patterns. All appropriate parameters are available in the inspector and are designer-friendly. Feature represents precisely what was asked for in specifications. |
| D (80) | Code has minor errors which do not significantly affect performance. Contains no irrelevant code. Where appropriate, parameters are available in the inspector and are designer-friendly. Feature does not deviate from what was asked for in specifications in any meaningful way. |
| CR (70) | Minor errors that affect performance. Problems are solved in convoluted ways. Contains some irrelevant copied code. Feature may competently resemble what was asked for in specifications, but with some deviations. |
| P (60) | Code is functional but has major flaws. Contains large passages of copied code irrelevant to the problem. Feature resembles what was asked for in specifications, but with prevalent deviations. |
| F (0-40) | Feature is unrecognisable to what is asked for in the specifications or features a game breaking bug. |

#### Clarity (50%) per feature attempted

| Grade |  Criteria |
| ----- | --------- |
| HD (100) | Code relevant to this feature has full compliance with the C# Style Guide. Code is easily readable. Well-designed code architecture. All relevant classes appropriately encapsulated. |
| D (80) | Code relevant to this feature demonstrates full compliance with the C# Style Guide with only minor typos. Code is readable with no significant code-smell. Code architecture is adequate. |
| CR (70) | Code relevant to this feature has general compliance with the C# Style Guide, with some minor issues. Code is readable but has some code-smell that needs to be addressed. Code architecture is adequate but could be improved. |
| P (60) | Code relevant to this feature has inconsistent application of C# Style Guide. Significant issues with readability or code-smell. Architecture is difficult to follow. |
| F (0-40) | Significant issues. Inconsistent style. Poor readability with code-smell issues. Messy code architecture with significant encapsulation violations. |

The final 20% of your grade will be determined by your Documentation, marked as indicated in the template report file.

#### ERD (5%)

| Grade    | Criteria |
| -------- | --- | 
| HD (100) | Thorough, detailed and clear ERD, accurately describing all the relevant objects in the game and their relationships. |
| D (80)   | A detailed and clear ERD that accurately represents all relevant objects in the game. |
| CR (70)  | A clear ERD correctly showing the main objects in your game. Some incompleteness in terms of structure and detail. |
| P (60)   | Shows understanding of the ERD format, but significant gaps in the documentation, or discrepancies between document and code. |
| F (0-40) | ERD is missing or shows little understanding of the format or purpose of ERDs in documentation. |

#### Project Management (5%)

| Grade      | Criteria |
| ---------- | -------- | 
| HD (100)   | Task allocation shows clear allocation of all necessary tasks. Tasks descriptions clear and professional. Workload is carefully balanced. Feature-branching version control workflow correctly implemented with clear distinction between develop and main branches. Work committed frequently in meaningful chunks. Professional commit messages that meaningfully document changes made. Correct use of .gitignore and Git LFS with Unity. Prefab-based scene construction used to avoid merge conflicts in scene edits. |
| D (80)     |    Task allocation shows clear allocation of major tasks. Tasks clearly described. Workload is balanced. Feature-branching version control workflow implemented correctly. Work committed regularly in meaningful chunks. Commit messages meaningfully document changes made. Correct use of .gitignore and Git LFS with Unity. Prefab-based scene construction used to avoid merge conflicts in scene edits. |
| CR (70)    |    Task allocation shows clear allocation of most tasks. Some vagueness in task descriptions. Workload is mostly balanced. Feature-branching version control workflow largely implemented correctly with minor errors. Multiple commits over the life of the project. Commit messages refer to changes made without detail. Correct use of .gitignore with Unity. Prefab-based scene construction used to avoid merge conflicts in scene edits. |
| P (60)     |    Significant gaps in task allocation. Task descriptions overly brief or otherwise vague. Workload is roughly balanced. Version control workflow significantly deviates from expected workflow. Multiple commits over the life of the project. Commit messages sometimes vague or missing. Poor use of .gitignore. |
| F (0-40)   |  Major gaps in task allocation. Task descriptions overly brief or otherwise vague. Workload is poorly balanced. Version control is poorly used with little discipline. Only a small number of large commits made. Commit messages often vague or missing. No use of .gitignore. |

#### Quality Assurance (5%)

| Grade     | Criteria |
| --------- | -------- | 
| HD (100)  | A thorough testing plan covering all the required features, with detailed instructions and expectations. Includes tests for unusual corner cases. Specific test scenes provided where appropriate. |
| D (80)    | A thorough testing plan covering all the required features, with detailed instructions and expectations. |
| CR (70)   | A testing plan covering all the required features, with clear instructions and expectations. |
| P (60)    | A testing plan covering most the required features. Some vagueness in instructions and expectations. |
| F (0-40)  | A testing plan that misses significant requirements. General vagueness in instructions and expectations. |

#### Data Manageent Plan (5%)

| Grade      | Criteria |
| ---------- | -------- | 
| HD (100) | Data Management Plan is expertly crafted, with careful consideration and integration of data management practices, and relevant ethical/legal responsibilities. |
| D (80)   | Data Management Plan is well crafted and clear, with considered integration of data management practices, and relevant ethical/legal responsibilities. |
| CR (70)  | Data Management Plan is well crafted with only minor problems with clarity. Data management practices are aligned with relevant ethical and legal responsibilities. | 
| P (60)   | Data Management Plan may have some vagueness or lack clarity. Ethical/legal responsibilities are correctly referenced, but practices may be slightly misaligned. |
| F (0-40) | Data Management Plan is difficult to read due to lack of clarity or spelling/grammar mistakes. Ethical/legal responsibilities around data management are missing or only superficially present. |
