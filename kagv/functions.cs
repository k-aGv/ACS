/*!
The MIT License (MIT)

Copyright (c) 2017 Dimitris Katikaridis <dkatikaridis@gmail.com>,Giannis Menekses <johnmenex@hotmail.com>

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in
all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
THE SOFTWARE.
*/
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.IO;

namespace kagv {

    public partial class main_form : IMessageFilter {

        //Message callback of key
        public bool PreFilterMessage(ref Message _msg) {
           
            if (_msg.Msg == 0x101) //0x101 means key is up
            {

                holdCTRL = false;
                panel_resize.Visible = false;
                toolStripStatusLabel1.Text = "Hold CTRL for grid configuration...";
                Refresh();
                return true;
            }
            return false;
        }

        //function for handling keystrokes and assigning specific actions to them
        protected override bool ProcessCmdKey(ref Message _msg, Keys _keyData) {
            bool emptymap = true;
            if (ModifierKeys.HasFlag(Keys.Control) && !holdCTRL) {

              

                for (int k = 0; k < Globals._WidthBlocks; k++) {
                    for (int l = 0; l < Globals._HeightBlocks; l++) {
                        if (m_rectangles[k][l].boxType != BoxType.Normal) {
                            emptymap = false;
                            break;
                        }
                    }
                    if (!emptymap) {
                        break;
                    }
                }

                if (!emptymap) {
                    DialogResult s = MessageBox.Show("Grid resize is only possible in an empty grid\nThe grid will be deleted.\nProceed?"
                                   , "Grid Resize triggered", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (s == DialogResult.Yes) {
                        holdCTRL = true;
                        UpdateGridStats();
                        toolStripStatusLabel1.Text = "Release CTRL to return...";
                        panel_resize.Visible = true;
                        FullyRestore();
                        return true;
                    } else return false;
                }

                if (overImage) {
                    DialogResult s = MessageBox.Show("Grid resize is only possible in an empty grid\nThe grid will be deleted.\nProceed?"
                                  , "Grid Resize triggered", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (s == DialogResult.Yes) {
                        holdCTRL = true;
                        UpdateGridStats();
                        toolStripStatusLabel1.Text = "Release CTRL to return...";
                        panel_resize.Visible = true;
                        overImage = false;
                        FullyRestore();
                        return true;
                    } else return false;
                } else {
                    holdCTRL = true;
                    UpdateGridStats();
                    toolStripStatusLabel1.Text = "Release CTRL to return...";
                    panel_resize.Visible = true;
                    return true;
                }

            }

            switch (_keyData) {
                case Keys.F5:
                    allToolStripMenuItem_Click(new object(), new EventArgs());
                    return true;
                default:
                    return false;
            }

        }
        /*-----------------------------------------------------*/
       

        //function that calculates all the intermediate points between each turning point (or jumpPoint if you may)
        private void DrawPoints(GridLine x, int agv_index) {
            //think of the incoming GridLine as follows:
            //If you want to move from A to B, there might be an obstacle in the way, which must be bypassed
            //For this purpose, there must be found a point to break the final route into 2 smaller (let's say A->b + b->B (AB in total)
            //The incoming GridLine contains the pair of Coordinates for each one of the smaller routes
            //So, for our example, GridLine x containts the starting A(x,y) & b(x,y)
            //In a nutshell, this functions calculates all the child-steps of the parent-Line, determined by x.fromX,x.fromY and x.toX,x.toY


            //the parent-Line will finaly consist of many pairs of (x,y): e.g [X1,Y1 / X2,Y2 / X3,Y3 ... Xn,Yn]
            Point[] currentLinePoints;//1d array of points.used to track all the points of current line

            int x1 = x.fromX;
            int y1 = x.fromY;
            int x2 = x.toX;
            int y2 = x.toY;
            double distance = __f.GetLength(x1, y1, x2, y2); //function that returns the Euclidean distance between 2 points

            double side = __f.getSide(m_rectangles[0][0].height
                            , m_rectangles[0][0].height); //function that returns the hypotenuse of a GridBox

            int distanceBlocks = -1; //the quantity of blocks,matching the current line's length

            //Calculates the number of GridBoxes that the Line consists of. Calculation depends on 2 scenarios:
            //Scenario 1: Line is Diagonal
            //Scenario 2: Line is Straight
            if ((x1 < x2) && (y1 < y2)) //diagonal-right bottom direction
                distanceBlocks = Convert.ToInt32(distance / side);
            else if ((x1 < x2) && (y1 > y2)) //diagonal-right top direction
                distanceBlocks = Convert.ToInt32(distance / side);
            else if ((x1 > x2) && (y1 < y2)) //diagonal-left bottom direction
                distanceBlocks = Convert.ToInt32(distance / side);
            else if ((x1 > x2) && (y1 > y2)) //diagonal-left top direction
                distanceBlocks = Convert.ToInt32(distance / side);
            else if ((y1 == y2) || (x1 == x2)) //horizontal or vertical
                distanceBlocks = Convert.ToInt32(distance / m_rectangles[0][0].width);
            else
                MessageBox.Show(this, "Unexpected error", "", MessageBoxButtons.OK, MessageBoxIcon.Error);


            currentLinePoints = new Point[distanceBlocks];
            double t;
            //here we calculate the X,Y coordinates of all the intermediate points
            for (int i = 0; i < distanceBlocks; i++) {
                calibrated = false;

                if (distance != 0) //obviously, distance cannot be zero
                    t = ((side) / distance);
                else
                    return;

                //these are the x,y coord that are calculated in every for-loop
                a = Convert.ToInt32(((1 - t) * x1) + (t * x2));
                b = Convert.ToInt32(((1 - t) * y1) + (t * y2));
                Point _p = new Point(a, b); //merges the calculated x,y into 1 Point variable

                for (int k = 0; k < Globals._WidthBlocks; k++)
                    for (int l = 0; l < Globals._HeightBlocks; l++)
                        if (m_rectangles[k][l].boxRec.Contains(_p)) { //this is how we assign the previously calculated pair of X,Y to a GridBox

                            //a smart way to handle GridBoxes from their center
                            int sideX = m_rectangles[k][l].boxRec.X + ((Globals._BlockSide / 2) - 1);
                            int sideY = m_rectangles[k][l].boxRec.Y + ((Globals._BlockSide / 2) - 1);
                            currentLinePoints[i].X = sideX;
                            currentLinePoints[i].Y = sideY;

                            if (dotsToolStripMenuItem.Checked) {
                                using (SolidBrush br = new SolidBrush(Color.BlueViolet))
                                    paper.FillEllipse(br, currentLinePoints[i].X - 3,
                                        currentLinePoints[i].Y - 3,
                                        5, 5);
                            }

                            using (Font stepFont = new Font("Tahoma", 8, FontStyle.Bold))//Font used for numbering the steps/current block)
                            {
                                using (SolidBrush fontBR = new SolidBrush(Color.FromArgb(53, 153, 153)))
                                    if (stepsToolStripMenuItem.Checked)
                                        paper.DrawString(AGVs[agv_index].StepsCounter + ""
                                        , stepFont
                                        , fontBR
                                        , currentLinePoints[i]);

                            }
                            calibrated = true;

                        }

                if (calibrated) { //for each one of the above calculations, we check if the calibration has been done correctly and, if so, each pair is inserted to the corresponding AGV's steps List 
                    AGVs[agv_index].Steps[AGVs[agv_index].StepsCounter].X = currentLinePoints[i].X;
                    AGVs[agv_index].Steps[AGVs[agv_index].StepsCounter].Y = currentLinePoints[i].Y;
                    AGVs[agv_index].StepsCounter++;
                }
                //initialize next steps.
                x1 = currentLinePoints[i].X;
                y1 = currentLinePoints[i].Y;
                distance = __f.GetLength(x1, y1, x2, y2);

            }


        }

        //function that resets all of the used objects so they are ready for reuse, preventing memory leaks
        private void FullyRestore() {

            if (trappedStatus != null)
                Array.Clear(trappedStatus, 0, trappedStatus.GetLength(0));

            if (importmap != null) {
                Array.Clear(importmap, 0, importmap.GetLength(0));
                Array.Clear(importmap, 0, importmap.GetLength(1));
            }

            if (BackgroundImage != null)
                BackgroundImage = null;

            startPos = new List<GridPos>();
            selectedColor = Color.DarkGray;

            for (int i = 0; i < startPos.Count(); i++)
                AGVs[i].JumpPoints = new List<GridPos>();

            
            searchGrid = new StaticGrid(Globals._WidthBlocks, Globals._HeightBlocks);

            alwaysCross =
            aGVIndexToolStripMenuItem.Checked =
            beforeStart =
            allowHighlight = true;

            atLeastOneObstacle =
            ifNoObstacles =
            never =
            imported =
            calibrated =
            isMouseDown =
            mapHasLoads = false;

            use_Halt = false;
            priorityRulesbetaToolStripMenuItem.Checked = false;

            importedLayout = null;
            jumpParam = null;
            paper = null;

            a
            = b
            = new int();


            AGVs = new List<Vehicle>();
           
            allowHighlight = true;
            highlightOverCurrentBoxToolStripMenuItem.Enabled = true;
            highlightOverCurrentBoxToolStripMenuItem.Checked = true;



            isLoad = new int[Globals._WidthBlocks, Globals._HeightBlocks];
            m_rectangles = new GridBox[Globals._WidthBlocks][];
            for (int widthTrav = 0; widthTrav < Globals._WidthBlocks; widthTrav++)
                m_rectangles[widthTrav] = new GridBox[Globals._HeightBlocks];

            //jagged array has to be resetted like this
            for (int i = 0; i < Globals._WidthBlocks; i++)
                for (int j = 0; j < Globals._HeightBlocks; j++)
                    m_rectangles[i][j] = new GridBox(i * Globals._BlockSide, j * Globals._BlockSide + Globals._TopBarOffset, BoxType.Normal);

           
            Initialization();

            main_form_Load(new object(), new EventArgs());

            for (int i = 0; i < AGVs.Count; i++)
                AGVs[i].Status.Busy = false;

            Globals._TimerStep = 0;
           
            nUD_AGVs.Value = AGVs.Count;
            
        }

        //has to do with optical features in the Grid option from the menu
        private void UpdateBorderVisibility(bool hide) {
            if (hide) {
                for (int i = 0; i < Globals._WidthBlocks; i++)
                    for (int j = 0; j < Globals._HeightBlocks; j++)
                        m_rectangles[i][j].BeTransparent();
                BackColor = Color.DarkGray;
            } else {
                for (int i = 0; i < Globals._WidthBlocks; i++)
                    for (int j = 0; j < Globals._HeightBlocks; j++)
                        if (m_rectangles[i][j].boxType == BoxType.Normal) {
                            m_rectangles[i][j].BeVisible();

                            boxDefaultColor = Globals._SemiTransparency ? Color.FromArgb(128, 255, 0, 255) : Color.WhiteSmoke;
                        }
                BackColor = selectedColor;
            }

            //no need of invalidation since its done after the call of this function
        }

        //returns the number of AGVs
        private int GetNumberOfAGVs() {
            int agvs = 0;
            for (int i = 0; i < Globals._WidthBlocks; i++)
                for (int j = 0; j < Globals._HeightBlocks; j++)
                    if (m_rectangles[i][j].boxType == BoxType.Start)
                        agvs++;

            return agvs;
        }

        //function that returns a list that contains the Available for action AGVs
        private List<GridPos> NotTrappedVehicles(List<GridPos> Vehicles, GridPos End) {
            //Vehicles is a list with all the AGVs that are inserted in the Grid by the user
            int list_index = 0;
            int trapped_index = 0;
            bool removed;

            //First, we must assume that ALL the AGVs are trapped and cannot move (trapped means they are prevented from reaching the END block)
            for (int i = 0; i < trappedStatus.Length; i++)
                trappedStatus[i] = true;

            do {
                removed = false;
                jumpParam.Reset(Vehicles[list_index], End); //we use the A* setting function and pass the 
                                                            //initial start point of every AGV and the final destination (end block)
                if (AStarFinder.FindPath(jumpParam, nud_weight.Value).Count == 0) //if the number of JumpPoints that is calculated is 0 (zero)
                {                                                          //it means that there was no path found
                    Vehicles.Remove(Vehicles[list_index]); //we removed, from the returning list, the AGV for which there was no path found
                    AGVs.Remove(AGVs[list_index]); //we remove the corresponding AGV from the public list that contains all the AGVs which will participate in the simulation
                    removed = true;
                } else
                    trappedStatus[trapped_index] = false; //since it's not trapped, we switch its state to false 

                if (!removed) {
                    AGVs[list_index].ID = list_index;
                    list_index++;
                }
                trapped_index++;
            }
            while (list_index < Vehicles.Count); //the above process will be repeated until all elements of the incoming List are parsed.
            return Vehicles; //list with NOT TRAPPED AGVs' starting points (trapped AGVs have been removed)


            //the point of this function is to consider every AGV as trap and then find out which AGVs
            //eventually, are not trapped and keep ONLY those ones.
        }

        //Basic path planner function
        private void Redraw() {

            bool start_found = false;
            bool end_found = false;
            mapHasLoads = false;

            GridPos endPos = new GridPos();

            pos_index = 0;
            startPos = new List<GridPos>(); //list that will be filled with the starting points of every AGV
            AGVs = new List<Vehicle>();  //list that will be filled with objects of the class Vehicle
            loadPos = new List<GridPos>(); //list that will be filled with the points of every Load
           
            //Double FOR-loops to scan the whole Grid and perform the needed actions
            for (int i = 0; i < Globals._WidthBlocks; i++)
                for (int j = 0; j < Globals._HeightBlocks; j++) {

                    if (m_rectangles[i][j].boxType == BoxType.Wall)
                        searchGrid.SetWalkableAt(new GridPos(i, j), false);//Walls are marked as non-walkable
                    else
                        searchGrid.SetWalkableAt(new GridPos(i, j), true);//every other block is marked as walkable (for now)

                    if (m_rectangles[i][j].boxType == BoxType.Load) {
                        mapHasLoads = true;
                        searchGrid.SetWalkableAt(new GridPos(i, j), false); //marks every Load as non-walkable
                        isLoad[i, j] = 1; //considers every Load as available
                        loadPos.Add(new GridPos(i, j)); //inserts the coordinates of the Load inside a list
                    }
                    if (m_rectangles[i][j].boxType == BoxType.Normal)
                        m_rectangles[i][j].onHover(boxDefaultColor);

                    if (m_rectangles[i][j].boxType == BoxType.Start) {

                        if (beforeStart) {
                            searchGrid.SetWalkableAt(new GridPos(i, j), false); //initial starting points of AGV are non walkable until 1st run is completed
                        } else
                            searchGrid.SetWalkableAt(new GridPos(i, j), true);

                        start_found = true;

                        AGVs.Add(new Vehicle(this));
                        AGVs[pos_index].ID = pos_index;

                        startPos.Add(new GridPos(i, j)); //adds the starting coordinates of an AGV to the StartPos list

                        //a & b are used by DrawPoints() as the starting x,y for calculation purposes
                        a = startPos[pos_index].x;
                        b = startPos[pos_index].y;

                        if (pos_index < startPos.Count) {
                            startPos[pos_index] = new GridPos(startPos[pos_index].x, startPos[pos_index].y);
                            pos_index++;
                        }
                    }

                    if (m_rectangles[i][j].boxType == BoxType.End) {
                        end_found = true;
                        endPos.x = i;
                        endPos.y = j;
                    }
                }

    

            if (!start_found || !end_found)
                return; //will return if there are no starting or end points in the Grid


            pos_index = 0;

            if (AGVs != null)
                for (int i = 0; i < AGVs.Count(); i++)
                    if (AGVs[i] != null) {
                        AGVs[i].Status.Busy = false; //initialize the status of AGVs, as 'available'
                    }

            startPos = NotTrappedVehicles(startPos, endPos); //replaces the List with all the inserted AGVs
                                                             //with a new one containing the right ones
            if (mapHasLoads)
                KeepValidLoads(endPos); //calls a function that checks which Loads are available
                                        //to be picked up by AGVs and removed the trapped ones.


            //For-loop to repeat the path-finding process for ALL the AGVs that participate in the simulation
            for (int i = 0; i < startPos.Count; i++) {
                if (loadPos.Count != 0)
                    loadPos = CheckForTrappedLoads(loadPos,endPos);

                if (loadPos.Count == 0) {
                    mapHasLoads = false;
                    AGVs[i].HasLoadToPick = false;
                } else {
                    mapHasLoads = true;
                    AGVs[i].HasLoadToPick = true;
                }


                if (AGVs[i].Status.Busy == false) {
                    List<GridPos> JumpPointsList;
                    switch (mapHasLoads) {
                        case true:
                            //====create the path FROM START TO LOAD, if load exists=====
                            for (int m = 0; m < loadPos.Count; m++)
                                searchGrid.SetWalkableAt(loadPos[m], false); //Do not allow walk over any other load except the targeted one
                            searchGrid.SetWalkableAt(loadPos[0], true);

                            //use of the A* alorithms to find the path between AGV and its marked Load
                            jumpParam.Reset(startPos[pos_index], loadPos[0]);
                            JumpPointsList = AStarFinder.FindPath(jumpParam, nud_weight.Value);
                            AGVs[i].JumpPoints = JumpPointsList;
                            AGVs[i].Status.Busy = true;
                            //====create the path FROM START TO LOAD, if load exists=====

                            //======FROM LOAD TO END======
                            for (int m = 0; m < loadPos.Count; m++)
                                searchGrid.SetWalkableAt(loadPos[m], false);
                            jumpParam.Reset(loadPos[0], endPos);
                            JumpPointsList = AStarFinder.FindPath(jumpParam, nud_weight.Value);
                            AGVs[i].JumpPoints.AddRange(JumpPointsList);

                            //marks the load that each AGV picks up on the 1st route, as 3, so each agv knows where to go after delivering the 1st load
                            isLoad[loadPos[0].x, loadPos[0].y] = 3;
                            AGVs[i].MarkedLoad = new Point(loadPos[0].x, loadPos[0].y);

                            loadPos.Remove(loadPos[0]);
                            //======FROM LOAD TO END======
                            break;
                        case false:
                            jumpParam.Reset(startPos[pos_index], endPos);
                            JumpPointsList = AStarFinder.FindPath(jumpParam, nud_weight.Value);

                            AGVs[i].JumpPoints = JumpPointsList;
                            break;
                    }
                }
                pos_index++;
            }

            int c = 0;
            for (int i = 0; i < startPos.Count; i++)
                c += AGVs[i].JumpPoints.Count;


            for (int i = 0; i < startPos.Count; i++)
                for (int j = 0; j < AGVs[i].JumpPoints.Count - 1; j++) {
                    GridLine line = new GridLine
                        (
                        m_rectangles[AGVs[i].JumpPoints[j].x][AGVs[i].JumpPoints[j].y],
                        m_rectangles[AGVs[i].JumpPoints[j + 1].x][AGVs[i].JumpPoints[j + 1].y]
                        );

                    AGVs[i].Paths[j] = line;
                }

            for (int i = 0; i < startPos.Count; i++)
                if ((c - 1) > 0)
                    Array.Resize(ref AGVs[i].Paths, c - 1); //resize of the AGVs steps Table
           
            Invalidate();
        }

        //function that determines which loads are valid to keep and which are not
        private void KeepValidLoads(GridPos EndPoint) {
            int list_index = 0;
            bool removed;
            for (int i = 0; i < loadPos.Count; i++)
                searchGrid.SetWalkableAt(loadPos[i], true); //assumes that all loads are walkable
                                                            //and only walls are in fact the only obstacles in the grid

            do {
                removed = false;
                jumpParam.Reset(loadPos[list_index], EndPoint); //tries to find path between each Load and the exit
                if (AStarFinder.FindPath(jumpParam, nud_weight.Value).Count == 0) //if no path is found
                {
                    isLoad[loadPos[list_index].x, loadPos[list_index].y] = 2; //mark the corresponding load as NOT available
                    loadPos.RemoveAt(list_index); //remove that load from the list
                    removed = true;
                }
                if (!removed) {
                    list_index++;
                }

            } while (list_index < loadPos.Count); //loop repeats untill all loads are checked

            if (loadPos.Count == 0)
                mapHasLoads = false;
        }

        //function that scans and finds which loads are surrounded by other loads
        private List<GridPos> CheckForTrappedLoads(List<GridPos> pos, GridPos endPos) {
            int list_index = 0;

            for (int i = 0; i < pos.Count; i++) {
                searchGrid.SetWalkableAt(pos[i], false);
                isLoad[pos[i].x, pos[i].y] = 4;
            }

            //if the 1st AGV  cannot reach a Load, then that Load is  
            //removed from the loadPos and not considered as available - marked as "4"  (temporarily trapped)
            do {
                searchGrid.SetWalkableAt(new GridPos(pos[0].x, pos[0].y), true);
                jumpParam.Reset(pos[0], endPos);
                if (AStarFinder.FindPath(jumpParam, nud_weight.Value).Count == 0) {
                    searchGrid.SetWalkableAt(new GridPos(pos[0].x, pos[0].y), false);
                    pos.Remove(pos[0]); //load is removed from the List with available Loads

                } else {
                    isLoad[pos[0].x, pos[0].y] = 1; //otherwise, Load is marked as available
                    list_index = pos.Count;
                }
            } while (list_index < pos.Count);

            return pos;
        }

        private void ConfigUI() {

            for (int i = 0; i < startPos.Count; i++) {
                AGVs[i] = new Vehicle(this);
                AGVs[i].ID = i;
            }

            Width = ((Globals._WidthBlocks + 1) * Globals._BlockSide) ;
            Height = (Globals._HeightBlocks + 1) * Globals._BlockSide + Globals._BottomBarOffset + 7; //+7 for borders
            Size = new Size(Width, Height + Globals._BottomBarOffset);
            MaximizeBox = false;
            FormBorderStyle = FormBorderStyle.FixedSingle;

           
            stepsToolStripMenuItem.Checked = false;
            linesToolStripMenuItem.Checked =
            dotsToolStripMenuItem.Checked =
            bordersToolStripMenuItem.Checked =
            aGVIndexToolStripMenuItem.Checked =
            highlightOverCurrentBoxToolStripMenuItem.Checked = true;

            Text = "K-aGv2 Simulator (ACS branch)";

            rb_start.Checked = true;
            BackColor = Color.DarkGray;

            CenterToScreen();

            alwaysCrossMenu.Checked = alwaysCross;
            atLeastOneMenu.Checked = atLeastOneObstacle;
            neverCrossMenu.Checked = never;
            noObstaclesMenu.Checked = ifNoObstacles;

            manhattanToolStripMenuItem.Checked = true;

            //dynamically add the location of menupanel.
            //We have to do it dynamically because the forms size is always depended on PCs actual screen size
            menuPanel.Width = Width;
            menuPanel.Location = new Point(0, settings_menu.Height);
            panel_resize.Location = new Point(Width / 2 - (panel_resize.Width / 2), Height / 2 - menuPanel.Height);
            panel_resize.Visible = false;
            nud_side.BackColor = panel_resize.BackColor;

            nud_weight.Value = Convert.ToDecimal(Globals._AStarWeight);
            
            statusStrip1.BringToFront();

            tp = new ToolTip
            {

                AutomaticDelay = 0,
                ReshowDelay = 0,
                InitialDelay = 0,
                AutoPopDelay = 0,
                IsBalloon = true,
                ToolTipIcon = ToolTipIcon.Info,
                ToolTipTitle = "Grid Block Information",
            };

        }

        private void MeasureScreen() {
            Location = Screen.PrimaryScreen.Bounds.Location;

            int usableSize = Screen.PrimaryScreen.Bounds.Height - menuPanel.Height - Globals._BottomBarOffset - Globals._TopBarOffset;
            Globals._HeightBlocks = usableSize / Globals._BlockSide;

            usableSize = Screen.PrimaryScreen.Bounds.Width;
            Globals._WidthBlocks = usableSize / Globals._BlockSide;
            
        }

        //Initializes all the objects in main_form
        private void Initialization() {
            if (Globals._FirstFormLoad) {
                if (File.Exists("info.txt")) {
                    StreamReader reader = new StreamReader("info.txt");
                    try {
                        Globals._WidthBlocks = Convert.ToInt32(reader.ReadLine());
                        Globals._HeightBlocks = Convert.ToInt32(reader.ReadLine());
                        Globals._BlockSide = Convert.ToInt32(reader.ReadLine());
                    } catch { MessageBox.Show("An error has occured while parsing the file to initialize form.\nPlease delete the file."); }
                    reader.Dispose();
                }
                Globals._FirstFormLoad = false;
            }

            isLoad = new int[Globals._WidthBlocks, Globals._HeightBlocks];
            //m_rectangels is an array of two 1d arrays
            //declares the length of the first 1d array
            m_rectangles = new GridBox[Globals._WidthBlocks][];


            for (int widthTrav = 0; widthTrav < Globals._WidthBlocks; widthTrav++) {
                //declares the length of the seconds 1d array
                m_rectangles[widthTrav] = new GridBox[Globals._HeightBlocks];
                for (int heightTrav = 0; heightTrav < Globals._HeightBlocks; heightTrav++) {

                    //dynamically add the gridboxes into the m_rectangles.
                    //size of the m_rectangels is constantly increasing (while adding
                    //the gridbox values) until size=height or size = width.
                    if (imported) { //this IF is executed as long as the user has imported a map of his choice
                        m_rectangles[widthTrav][heightTrav] = new GridBox((widthTrav * Globals._BlockSide) , heightTrav * Globals._BlockSide + Globals._TopBarOffset, importmap[widthTrav, heightTrav]);
                        if (importmap[widthTrav, heightTrav] == BoxType.Load) {
                            isLoad[widthTrav, heightTrav] = 1;
                        }
                    } else {
                        m_rectangles[widthTrav][heightTrav] = new GridBox((widthTrav * Globals._BlockSide) , heightTrav * Globals._BlockSide + Globals._TopBarOffset, BoxType.Normal);
                        isLoad[widthTrav, heightTrav] = 2;
                    }


                }
            }
            if (imported)
                imported = false;


            searchGrid = new StaticGrid(Globals._WidthBlocks, Globals._HeightBlocks);
            jumpParam = new AStarParam(searchGrid, Convert.ToSingle(Globals._AStarWeight));//Default value until user edit it
            jumpParam.SetHeuristic(HeuristicMode.MANHATTAN); //default value until user edit it

            ConfigUI();
        }

        //Function for exporting the map
        private void Export()
        {

            int loads=0;
            for (int i = 0; i < Globals._HeightBlocks; i++)
                for (int j = 0; j < Globals._WidthBlocks; j++)
                    if (m_rectangles[j][i].boxType == BoxType.Load)
                        loads++;

            if (loads == 0) {
                MessageBox.Show("No loads were found on the Grid.\nExported file was not created.");
                return;
            }

            sfd_exportmap.FileName = "";
            sfd_exportmap.Filter = "kagv Map (*.kmap)|*.kmap";

            if (sfd_exportmap.ShowDialog() == DialogResult.OK) {
                StreamWriter _writer = new StreamWriter(sfd_exportmap.FileName);
                for (int i = 0; i < Globals._HeightBlocks; i++)
                    for (int j = 0; j < Globals._WidthBlocks; j++)
                        if (m_rectangles[j][i].boxType == BoxType.Load) {
                            _writer.WriteLine(m_rectangles[j][i].x + "," + (this.Size.Height - m_rectangles[j][i].y));
                        }
                _writer.Close();
            } else
                return;
        }

        //Function for importing a map 
        private void Import() {
            MessageBox.Show("Not available yet");
            ofd_importmap.Filter = "kagv Map (*.kmap)|*.kmap";
            ofd_importmap.FileName = "";


            if (ofd_importmap.ShowDialog() == DialogResult.OK) {
                bool proceed = false;
                string _line = "";
                char[] sep = { ':', ' ' };

                StreamReader reader = new StreamReader(ofd_importmap.FileName);
                do {
                    _line = reader.ReadLine();
                    if (_line.Contains("Width blocks:") && _line.Contains("Height blocks:") && _line.Contains("BlockSide:"))
                        proceed = true;
                } while (!(_line.Contains("Width blocks:") && _line.Contains("Height blocks:") && _line.Contains("BlockSide:")) &&
                         !reader.EndOfStream);
                string[] _lineArray = _line.Split(sep);


                if (proceed) {

                    Globals._WidthBlocks = Convert.ToInt32(_lineArray[3]);
                    Globals._HeightBlocks = Convert.ToInt32(_lineArray[8]);
                    Globals._BlockSide = Convert.ToInt32(_lineArray[12]);

                    FullyRestore();

                    string[] words;
                    char[] delim = { ' ' };
                    reader.ReadLine();
                    importmap = new BoxType[Globals._WidthBlocks, Globals._HeightBlocks];
                    words = reader.ReadLine().Split(delim);

                    int starts_counter = 0;
                    for (int z = 0; z < importmap.GetLength(0); z++) {
                        int i = 0;
                        foreach (string _s in words)
                            if (i < importmap.GetLength(1)) {
                                if (_s == "Start") {
                                    importmap[z, i] = BoxType.Start;
                                    starts_counter++;
                                } else if (_s == "End")
                                    importmap[z, i] = BoxType.End;
                                else if (_s == "Normal")
                                    importmap[z, i] = BoxType.Normal;
                                else if (_s == "Wall")
                                    importmap[z, i] = BoxType.Wall;
                                else if (_s == "Load")
                                    importmap[z, i] = BoxType.Load;
                                i++;
                            }
                        if (z == importmap.GetLength(0) - 1) { } else
                            words = reader.ReadLine().Split(delim);
                    }
                    reader.Close();

                    nUD_AGVs.Value = starts_counter;
                    imported = true;
                    Initialization();
                    Redraw();
                    if (overImage) {
                        overImage = false;
                    }
                } else
                    MessageBox.Show(this, "You have chosen an incompatible file import.\r\nPlease try again.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Function that validates the user's click 
        private bool Isvalid(Point _temp) {

            //The function received the coordinates of the user's click.
            //Clicking anywhere but on the Grid itself, will cause a "false" return, preventing
            //the click from giving any results

            if (_temp.Y < menuPanel.Location.Y)
                return false;

            if (_temp.X > m_rectangles[Globals._WidthBlocks - 1][Globals._HeightBlocks - 1].boxRec.X + (Globals._BlockSide - 1) 
            || _temp.Y > m_rectangles[Globals._WidthBlocks - 1][Globals._HeightBlocks - 1].boxRec.Y + (Globals._BlockSide - 1)) // 18 because its 20-boarder size
                return false;

            if (!m_rectangles[_temp.X / Globals._BlockSide][(_temp.Y - Globals._TopBarOffset) / Globals._BlockSide].boxRec.Contains(_temp))
                return false;

            return true;
        }

        private void UpdateGridStats() {
            int pixelsWidth = Globals._WidthBlocks * Globals._BlockSide;
            int pixelsHeight = Globals._HeightBlocks * Globals._BlockSide;
            lb_width.Text = "Width blocks: " + Globals._WidthBlocks + ".  " + pixelsWidth + " pixels";
            lb_height.Text = "Height blocks: " + Globals._HeightBlocks + ". " + pixelsHeight + " pixels";
            nud_side.Value = Convert.ToDecimal(Globals._BlockSide);
        }

    }
}
