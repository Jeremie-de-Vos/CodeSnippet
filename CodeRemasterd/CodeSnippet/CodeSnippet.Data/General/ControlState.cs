using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;

namespace CodeSnippet.Data.General
{
    public class ControlState
    {
        #region Decision Maker
        public static bool Execute(object controls, ControlStateVisuals visual)
        {
            //Determ object = list or array
            if (controls is List<ControlStateConfiger>)
                return List(controls as List<ControlStateConfiger>);
            else
            if (controls is Control[])
                return Array(controls as Control[], visual);
            else
                return false;
        }
        #endregion
        #region Array or List
        private static bool Array(Control[] con, ControlStateVisuals methode)
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
            List<ControlStateConfiger> C_list = null;
            Control[] C_array = null;


            //Determ object = list or array
            if (controls is List<ControlStateConfiger>)
                C_list = controls as List<ControlStateConfiger>;
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

                    else { }
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
        private static bool TextBoxState(TextBox t, ControlStateVisuals v)
        {
            //variable
            bool filled = false;
            ControlStateStatus state;

            //Check what the current state is
            if (t.Text == string.Empty)
            { state = ControlStateStatus.empty; }
            else if (t.Text == "error")
            { state = ControlStateStatus.error; }
            else
            { state = ControlStateStatus.filled; filled = true; }

            //Check what the methode is and make the action that belongs to it
            VisualAction(t, state, v);

            //check if a field was not filled
            return filled;
        }
        private static bool LabelState(Label t, ControlStateVisuals methode)
        {
            //variable
            bool Filled = false;
            ControlStateStatus state;

            switch (t.Content)
            {
                case "":
                    state = ControlStateStatus.empty;
                    break;
                case "error":
                    state = ControlStateStatus.error;
                    break;
                default:
                    state = ControlStateStatus.filled; Filled = true;
                    break;
            }

            //Check what the methode is and make the action that belongs to it
            VisualAction(t, state, methode);

            //check if a field was not filled
            return Filled;
        }
        private static bool RichTextBoxState(RichTextBox t, ControlStateVisuals v)
        {
            //variable
            bool Filled = false;
            ControlStateStatus state;
            string richText = new TextRange(t.Document.ContentStart, t.Document.ContentEnd).Text;

            //Check what the current state is
            if (richText == string.Empty)
            { state = ControlStateStatus.empty; }
            else if (richText == "error")
            { state = ControlStateStatus.error; }
            else
            { state = ControlStateStatus.filled; Filled = true; }

            //Check what the methode is and make the action that belongs to it
            VisualAction(t, state, v);

            //check if a field was not filled
            return Filled;
        }
        private static bool ComboBoxState(ComboBox t, ControlStateVisuals v)
        {
            //variable
            bool Filled = false;
            ControlStateStatus state;

            //Check what the current state is
            if (t.SelectedIndex == 0)
            { state = ControlStateStatus.empty; }
            else
            { state = ControlStateStatus.filled; Filled = true; }

            //Check what the methode is and make the action that belongs to it
            VisualAction(t, state, v);

            //check if a field was not filled
            return Filled;
        }
        #endregion
        #region Set-Visuals
        private static void SetState_color(Control t, ControlStateStatus s)
        {
            if (s == ControlStateStatus.empty)
                t.BorderBrush = System.Windows.Media.Brushes.Orange;
            else if (s == ControlStateStatus.error)
                t.BorderBrush = System.Windows.Media.Brushes.Red;
            else if (s == ControlStateStatus.filled)
                t.BorderBrush = System.Windows.Media.Brushes.LightGreen;
        }
        private static void VisualAction(Control t, ControlStateStatus state, ControlStateVisuals v)
        {
            if (v == ControlStateVisuals.Colored)
                SetState_color(t, state);
            else if (v == ControlStateVisuals.Background)
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
public enum ControlStateStatus
{
    empty,
    error,
    filled
}
public enum ControlStateVisuals
{
    Colored,
    Background
}
public class ControlStateConfiger
{
    internal Control Control;
    internal ControlStateVisuals Visuals;

    internal ControlStateConfiger(Control control, ControlStateVisuals visual)
    {
        Control = control;
        Visuals = visual;
    }
}