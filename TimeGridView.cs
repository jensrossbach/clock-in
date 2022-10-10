/*
 * Copyright (c) 2012-2022 Jens-Uwe Rossbach
 *
 * This code is licensed under the MIT License.
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in all
 * copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 * SOFTWARE.
 */


using System;
using System.Windows.Forms;


namespace ClockIn
{
    /// <summary>
    ///   A data grid view column holding date time cells
    /// </summary>
    public class DataGridViewTimeColumn : DataGridViewColumn
    {
        /// <summary>
        ///   Default constructor of the class
        /// </summary>
        public DataGridViewTimeColumn() : base(new DataGridViewTimeCell())
        {
            ValueType = base.CellTemplate.ValueType;
        }

        /// <summary>
        ///   Overrides the DataGridViewColumn.CellTemplate property.
        /// </summary>
        public override DataGridViewCell CellTemplate
        {
            get => base.CellTemplate;
            set
            {
                // ensure that the cell used for the template is a DataGridViewTimeCell
                if ((value != null) && (!value.GetType().IsAssignableFrom(typeof(DataGridViewTimeCell))))
                {
                    throw new InvalidCastException("Must be a DataGridViewTimeCell");
                }

                base.CellTemplate = value;
            }
        }
    }

    /// <summary>
    ///   A data grid view cell containing a date time
    /// </summary>
    public class DataGridViewTimeCell : DataGridViewTextBoxCell
    {
        /// <summary>
        ///   Default constructor of the class
        /// </summary>
        public DataGridViewTimeCell() : base()
        {
            // use the time format
            Style.Format = "t";
        }


        /// <summary>
        ///   Overrides the DataGridViewTextBoxCell.EditType property.
        ///   Return the type of the editing control that DataGridViewTimeCell uses.
        /// </summary>
        public override Type EditType => typeof(DataGridViewTimeEditingControl);

        /// <summary>
        ///   Overrides the DataGridViewTextBoxCell.ValueType property.
        ///   Return the type of the value that DataGridViewTimeCell contains.
        /// </summary>
        public override Type ValueType => typeof(DateTime);

        /// <summary>
        ///   Overrides the DataGridViewTextBoxCell.DefaultNewRowValue property.
        ///   Use the current date and time as the default value.
        /// </summary>
        public override object DefaultNewRowValue => DateTime.Now;


        /// <summary>
        ///   Overrides the DataGridViewTextBoxCell.InitializeEditingControl method.
        /// </summary>
        public override void InitializeEditingControl(int rowIndex, object initialFormattedValue, DataGridViewCellStyle dataGridViewCellStyle)
        {
            // set the value of the editing control to the current cell value
            base.InitializeEditingControl(rowIndex, initialFormattedValue, dataGridViewCellStyle);

            DataGridViewTimeEditingControl ctl = DataGridView.EditingControl as DataGridViewTimeEditingControl;

            // use the default row value when Value property is null
            if ((Value == null) || (Value == DBNull.Value))
            {
                ctl.Value = (DateTime)DefaultNewRowValue;
            }
            else
            {
                ctl.Value = (DateTime)Value;
            }
        }
    }

    /// <summary>
    ///   Control for editing date time cells in the data grid view
    /// </summary>
    class DataGridViewTimeEditingControl : DateTimePicker, IDataGridViewEditingControl
    {
        /// <summary>
        ///   Default constructor of the class
        /// </summary>
        public DataGridViewTimeEditingControl()
        {
            Format = DateTimePickerFormat.Custom;
            CustomFormat = "HH:mm";
            ShowUpDown = true;
        }

        /// <summary>
        ///   Implements the IDataGridViewEditingControl.EditingControlFormattedValue property.
        /// </summary>
        public object EditingControlFormattedValue
        {
            get => Value.ToShortTimeString();
            set
            {
                if (value is String)
                {
                    try
                    {
                        // this will throw an exception if the string is
                        // null, empty, or not in the format of a date
                        Value = DateTime.Parse((string)value);
                    }
                    catch
                    {
                        // in the case of an exception, just use the
                        // default value so we're not left with a null
                        // value
                        Value = DateTime.Now;
                    }
                }
            }
        }

        /// <summary>
        ///   Implements the IDataGridViewEditingControl.GetEditingControlFormattedValue property.
        /// </summary>
        public object GetEditingControlFormattedValue(DataGridViewDataErrorContexts context) => EditingControlFormattedValue;

        /// <summary>
        ///   Implements the IDataGridViewEditingControl.ApplyCellStyleToEditingControl property.
        /// </summary>
        public void ApplyCellStyleToEditingControl(DataGridViewCellStyle dataGridViewCellStyle)
        {
            Font = dataGridViewCellStyle.Font;
            CalendarForeColor = dataGridViewCellStyle.ForeColor;
            CalendarMonthBackground = dataGridViewCellStyle.BackColor;
        }

        /// <summary>
        ///   Implements the IDataGridViewEditingControl.EditingControlRowIndex property.
        /// </summary>
        public int EditingControlRowIndex { get; set; } = -1;

        /// <summary>
        ///   Implements the IDataGridViewEditingControl.RepositionEditingControlOnValueChange property.
        /// </summary>
        public bool RepositionEditingControlOnValueChange => false;

        /// <summary>
        ///   Implements the IDataGridViewEditingControl.EditingControlDataGridView property.
        /// </summary>
        public DataGridView EditingControlDataGridView { get; set; } = null;

        /// <summary>
        ///   Implements the IDataGridViewEditingControl.EditingControlValueChanged property.
        /// </summary>
        public bool EditingControlValueChanged { get; set; } = false;

        /// <summary>
        ///   Implements the IDataGridViewEditingControl.EditingPanelCursor property.
        /// </summary>
        public Cursor EditingPanelCursor => base.Cursor;

        /// <summary>
        ///   Implements the IDataGridViewEditingControl.EditingControlWantsInputKey method.
        /// </summary>
        public bool EditingControlWantsInputKey(Keys key, bool dataGridViewWantsInputKey)
        {
            // let the DateTimePicker handle the keys listed
            switch (key & Keys.KeyCode)
            {
                case Keys.Left:
                case Keys.Up:
                case Keys.Down:
                case Keys.Right:
                case Keys.Home:
                case Keys.End:
                case Keys.PageDown:
                case Keys.PageUp:
                    {
                        return true;
                    }
                default:
                    {
                        return !dataGridViewWantsInputKey;
                    }
            }
        }

        /// <summary>
        ///   Implements the IDataGridViewEditingControl.PrepareEditingControlForEdit method
        /// </summary>
        public void PrepareEditingControlForEdit(bool selectAll)
        {
            // no preparation needs to be done
        }

        /// <see>DateTimePicker.OnValueChanged</see>
        protected override void OnValueChanged(EventArgs eventargs)
        {
            // notify the DataGridView that the contents of the cell
            // have changed
            EditingControlValueChanged = true;

            EditingControlDataGridView.NotifyCurrentCellDirty(true);
            base.OnValueChanged(eventargs);
        }
    }
}
