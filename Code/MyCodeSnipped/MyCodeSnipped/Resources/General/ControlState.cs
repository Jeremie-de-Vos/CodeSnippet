using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;

namespace MyCodeSnipped.Resources.General
{
    class ControlState
    {
        #region Decision Maker
        internal static bool Execute(object controls, Visuals visual)
        {
            //Determ object = list or array
            if (controls is List<Control_>)
                return List(controls as List<Control_>);
            else
            if (controls is Control[])
                return Array(controls as Control[], visual);
            else
            {
                MessageBox.Show("This is not a list or array");
                return false;
            }
        }
        #endregion
        #region Array or List
        private static bool Array(Control[] con, Visuals methode)
        {
            //notfilled is that not everything has been filled yet
            bool NotFilled = false;

            //strart loop foreach control
            foreach (Control c in con)
            {
                c.KeyUp += Enter_;
                //determ what type of control it is
                if (c.IsEnabled)
                {
                    switch (c.GetType().Name)
                    {
                        case "TextBox":
                            if (!TextBoxState(c as TextBox, methode))
                                NotFilled = true;
                            break;

                        case "RichTextBox":
                            if (!RichTextBoxState(c as RichTextBox, methode))
                                NotFilled = true;
                            break;

                        case "ComboBox":
                            if (!ComboBoxState(c as ComboBox, methode))
                                NotFilled = true;
                            break;

                        case "Label":
                            if (!LabelState(c as Label, methode))
                                NotFilled = true;
                            break;


                        default:
                            MessageBox.Show(c.Name.ToString());
                            break;
                    }
                }
                else
                {
                    //if control is diabled set color state to white
                    c.BorderBrush = System.Windows.Media.Brushes.White;
                }
            }

            //check if a field was not filled
            if (NotFilled)
                return false;
            else
                return true;
        }
        private static bool List(object controls)
        {
            //notfilled is that not everything has been filled yet
            bool NotFilled = false;

            //LIst or Array?
            List<Control_> C_list = null;
            Control[] C_array = null;


            //Determ object = list or array
            if (controls is List<Control_>)
                C_list = controls as List<Control_>;
            else if (controls is Control[])
                C_array = controls as Control[];


            //Loop true Control list
            for (int i = 0; i < C_list.Count; i++)
            {
                C_list[i].Control.KeyUp += Enter_;
                //determ what type of control it is
                if (C_list[i].Control.IsEnabled)
                {
                    if (C_list[i].Control is TextBox)
                    {
                        if (!TextBoxState(C_list[i].Control as TextBox, C_list[i].Visuals))
                        {
                            NotFilled = true;
                        }
                    }

                    else if (C_list[i].Control is RichTextBox)
                    {
                        if (!RichTextBoxState(C_list[i].Control as RichTextBox, C_list[i].Visuals))
                        {
                            NotFilled = true;
                        }
                    }

                    else if (C_list[i].Control is ComboBox)
                    {
                        if (!ComboBoxState(C_list[i].Control as ComboBox, C_list[i].Visuals))
                        {
                            NotFilled = true;
                        }
                    }

                    else if (C_list[i].Control is Label)
                    {
                        if (!LabelState(C_list[i].Control as Label, C_list[i].Visuals))
                        {
                            NotFilled = true;
                        }
                    }

                    else { MessageBox.Show("Unknown Control! Or not not added yet :P"); }
                }
                else
                {
                    //if control is diabled set color state to white
                    C_list[i].Control.BorderBrush = System.Windows.Media.Brushes.White;
                }
            }
            //check if a field was not filled
            return !NotFilled;
        }
        #endregion
        #region Controls-Checkers
        private static bool TextBoxState(TextBox t, Visuals v)
        {
            //variable
            bool filled = false;
            Status state;

            //Check what the current state is
            if (t.Text == string.Empty)
            { state = Status.empty; }
            else if (t.Text == "error")
            { state = Status.error; }
            else
            { state = Status.filled; filled = true; }

            //Check what the methode is and make the action that belongs to it
            VisualAction(t, state, v);

            //check if a field was not filled
            return filled;
        }
        private static bool LabelState(Label t, Visuals methode)
        {
            //variable
            bool Filled = false;
            Status state;

            //Check what the current state is
            if (t.Content == string.Empty)
            { state = Status.empty; }
            else if (t.Content == "error")
            { state = Status.error; }
            else
            { state = Status.filled; Filled = true; }

            //Check what the methode is and make the action that belongs to it
            VisualAction(t, state, methode);

            //check if a field was not filled
            return Filled;
        }
        private static bool RichTextBoxState(RichTextBox t, Visuals v)
        {
            //variable
            bool Filled = false;
            Status state;
            string richText = new TextRange(t.Document.ContentStart, t.Document.ContentEnd).Text;

            //Check what the current state is
            if (richText == string.Empty)
            { state = Status.empty; }
            else if (richText == "error")
            { state = Status.error; }
            else
            { state = Status.filled; Filled = true; }

            //Check what the methode is and make the action that belongs to it
            VisualAction(t, state, v);

            //check if a field was not filled
            return Filled;
        }
        private static bool ComboBoxState(ComboBox t, Visuals v)
        {
            //variable
            bool Filled = false;
            Status state;

            //Check what the current state is
            if (t.SelectedIndex == 0)
            { state = Status.empty; }
            else
            { state = Status.filled; Filled = true; }

            //Check what the methode is and make the action that belongs to it
            VisualAction(t, state, v);

            //check if a field was not filled
            return Filled;
        }
        #endregion
        #region Set-Visuals
        private static void SetState_color(Control t, Status s)
        {
            if (s == Status.empty)
                t.BorderBrush = System.Windows.Media.Brushes.Orange;
            else if (s == Status.error)
                t.BorderBrush = System.Windows.Media.Brushes.Red;
            else if (s == Status.filled)
                t.BorderBrush = System.Windows.Media.Brushes.LightGreen;
        }
        private static void VisualAction(Control t, Status state, Visuals v)
        {
            if (v == Visuals.Colored)
                SetState_color(t, state);
            else if (v == Visuals.Background)
                t.BorderBrush = System.Windows.Media.Brushes.White;
        }
        #endregion
        #region Events
        private static void Enter_(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {

            }
        }
        #endregion
    }
}
internal enum Status
{
    empty,
    error,
    filled
}
internal enum Visuals
{
    Colored,
    Background
}
internal class Control_
{
    internal Control Control;
    internal Visuals Visuals;

    internal Control_(Control control, Visuals visual)
    {
        Control = control;
        Visuals = visual;
    }
}