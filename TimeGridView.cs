using System;
using System.Windows.Forms;


namespace ClockIn
{
    public class DataGridViewTimeColumn : DataGridViewColumn
    {
        public DataGridViewTimeColumn() : base(new DataGridViewTimeCell())
        {
            ValueType = base.CellTemplate.ValueType;
        }

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

    public class DataGridViewTimeCell : DataGridViewTextBoxCell
    {

        public DataGridViewTimeCell() : base()
        {
            // use the time format
            Style.Format = "t";
        }

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

        public override Type EditType
        {
            get
            {
                // return the type of the editing control that DataGridViewTimeCell uses
                return typeof(DataGridViewTimeEditingControl);
            }
        }

        public override Type ValueType
        {
            get
            {
                // return the type of the value that DataGridViewTimeCell contains
                return typeof(DateTime);
            }
        }

        public override object DefaultNewRowValue
        {
            get
            {
                // use the current date and time as the default value
                return DateTime.Now;
            }
        }
    }

    class DataGridViewTimeEditingControl : DateTimePicker, IDataGridViewEditingControl
    {
        public DataGridViewTimeEditingControl()
        {
            Format = DateTimePickerFormat.Custom;
            CustomFormat = "HH:mm";
            ShowUpDown = true;
        }

        // implements the IDataGridViewEditingControl.EditingControlFormattedValue property
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

        // implements the IDataGridViewEditingControl.GetEditingControlFormattedValue method
        public object GetEditingControlFormattedValue(DataGridViewDataErrorContexts context)
        {
            return EditingControlFormattedValue;
        }

        // implements the IDataGridViewEditingControl.ApplyCellStyleToEditingControl method
        public void ApplyCellStyleToEditingControl(DataGridViewCellStyle dataGridViewCellStyle)
        {
            Font = dataGridViewCellStyle.Font;
            CalendarForeColor = dataGridViewCellStyle.ForeColor;
            CalendarMonthBackground = dataGridViewCellStyle.BackColor;
        }

        // implements the IDataGridViewEditingControl.EditingControlRowIndex property
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

        // implements the IDataGridViewEditingControl.EditingControlWantsInputKey method
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

        // implements the IDataGridViewEditingControl.PrepareEditingControlForEdit method
        public void PrepareEditingControlForEdit(bool selectAll)
        {
            // no preparation needs to be done
        }

        // implements the IDataGridViewEditingControl.RepositionEditingControlOnValueChange property
        public bool RepositionEditingControlOnValueChange
        {
            get
            {
                return false;
            }
        }

        // implements the IDataGridViewEditingControl.EditingControlDataGridView property
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

        // implements the IDataGridViewEditingControl.EditingControlValueChanged property
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

        // implements the IDataGridViewEditingControl.EditingPanelCursor property
        public Cursor EditingPanelCursor
        {
            get
            {
                return base.Cursor;
            }
        }

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
