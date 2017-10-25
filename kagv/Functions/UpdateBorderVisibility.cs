﻿/*!
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

    public partial class main_form {

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

                            Globals.boxDefaultColor = Globals._SemiTransparency ? Color.FromArgb(128, 255, 0, 255) : Color.WhiteSmoke;
                        }
                BackColor = selectedColor;
            }

            //no need of invalidation since its done after the call of this function
        }
    }
}