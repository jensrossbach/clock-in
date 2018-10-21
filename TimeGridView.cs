// ClockIn
// Copyright (C) 2012-2018 Jens Rossbach, All Rights Reserved.


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
            get
            {
                return base.CellTemplate;
            }
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
        /// </summary>
        public override Type EditType
        {
            get
            {
                // return the type of the editing control that DataGridViewTimeCell uses
                return typeof(DataGridViewTimeEditingControl);
            }
        }

        /// <summary>
        ///   Overrides the DataGridViewTextBoxCell.ValueType property.
        /// </summary>
        public override Type ValueType
        {
            get
            {
                // return the type of the value that DataGridViewTimeCell contains
                return typeof(DateTime);
            }
        }

        /// <summary>
        ///   Overrides the DataGridViewTextBoxCell.DefaultNewRowValue property.
        /// </summary>
        public override object DefaultNewRowValue
        {
            get
            {
                // use the current date and time as the default value
                return DateTime.Now;
            }
        }

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
            get
            {
                return Value.ToShortTimeString();
            }
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
        public object GetEditingControlFormattedValue(DataGridViewDataErrorContexts context)
        {
            return EditingControlFormattedValue;
        }

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
        public int EditingControlRowIndex
        {
            get
            {
                return rowIndex;
            }
            set
            {
                rowIndex = value;
            }
        }

        /// <summary>
        ///   Implements the IDataGridViewEditingControl.RepositionEditingControlOnValueChange property.
        /// </summary>
        public bool RepositionEditingControlOnValueChange
        {
            get
            {
                return false;
            }
        }

        /// <summary>
        ///   Implements the IDataGridViewEditingControl.EditingControlDataGridView property.
        /// </summary>
        public DataGridView EditingControlDataGridView
        {
            get
            {
                return dataGridView;
            }
            set
            {
                dataGridView = value;
            }
        }

        /// <summary>
        ///   Implements the IDataGridViewEditingControl.EditingControlValueChanged property.
        /// </summary>
        public bool EditingControlValueChanged
        {
            get
            {
                return valueChanged;
            }
            set
            {
                valueChanged = value;
            }
        }

        /// <summary>
        ///   Implements the IDataGridViewEditingControl.EditingPanelCursor property.
        /// </summary>
        public Cursor EditingPanelCursor
        {
            get
            {
                return base.Cursor;
            }
        }

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
            valueChanged = true;

            EditingControlDataGridView.NotifyCurrentCellDirty(true);
            base.OnValueChanged(eventargs);
        }

        private DataGridView dataGridView;
        private bool valueChanged = false;
        private int rowIndex;
    }
}
