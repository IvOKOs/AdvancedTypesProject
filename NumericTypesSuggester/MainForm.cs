using System.Numerics;

namespace NumericTypesSuggester
{
    
    public partial class MainForm : Form
    {
        private Dictionary<BigInteger, string> _integralPairs = new Dictionary<BigInteger, string>()
        {
            [byte.MaxValue] = "byte",
            [ushort.MaxValue] = "ushort",
            [uint.MaxValue] = "uint",
            [ulong.MaxValue] = "ulong",
            [sbyte.MaxValue] = "sbyte",
            [short.MaxValue] = "short",
            [int.MaxValue] = "int",
            [long.MaxValue] = "long",
        };
        private bool _isInvalid = false;
        public MainForm()
        {
            InitializeComponent();
            integralOnlyCheckBox.Checked = true;
        }

        private string? GetNumType()
        {
            string? resultType = null;
            var minVal = BigInteger.Parse(minValTextBox.Text);
            var maxVal = BigInteger.Parse(maxValueTextBox.Text);
            if (integralOnlyCheckBox.Checked)
            {
                if (minVal < 0)
                {
                    resultType = GetTypeFromNegativeMinimums(minVal, maxVal);
                }
                else
                {
                    resultType = GetTypeFromPositiveMinimums(minVal, maxVal);
                }
            }
            else
            {

            }

                return resultType;
        }

        private string GetTypeFromNegativeMinimums(BigInteger min, BigInteger max)
        {
            string? res = string.Empty;
            BigInteger key = default;
            if (min >= sbyte.MinValue && max <= sbyte.MaxValue)
            {
                key = sbyte.MaxValue;
            }
            else if (min >= short.MinValue && max <= short.MaxValue)
            {
                key = short.MaxValue;
            }
            else if (min >= int.MinValue && max <= int.MaxValue)
            {
                key = int.MaxValue;
            }
            else if (min >= long.MinValue && max <= long.MaxValue)
            {
                key = long.MaxValue;
            }
            return _integralPairs.TryGetValue(key, out res) ? res : "BigInteger";
        }

        private string GetTypeFromPositiveMinimums(BigInteger min, BigInteger max)
        {
            string? res = string.Empty;
            BigInteger key = default;
            if(max <= byte.MaxValue)
            {
                key = byte.MaxValue;
            }
            else if(max <= ushort.MaxValue)
            {
                key = ushort.MaxValue;
            }
            else if(max <= uint.MaxValue)
            {
                key = uint.MaxValue;
            }
            else
            {
                key = ulong.MaxValue;
            }
            return _integralPairs.TryGetValue(key, out res) ? res : "BigInteger";
        }

        private void CheckMinBiggerThanMax()
        {
            if (!BigInteger.TryParse(minValTextBox.Text, out BigInteger minVal))
            {
                return;
            }
            if (!BigInteger.TryParse(maxValueTextBox.Text, out BigInteger maxVal))
            {
                return;
            }
            if (minVal > maxVal)
            {
                maxValueTextBox.BackColor = Color.Red;
                return;
            }
            maxValueTextBox.BackColor = Color.White;
        }

        private bool IsValidNum(char keyChar)
        {
            if (!char.IsDigit(keyChar))
            {
                return false;
            }
            return true;
        }

        private bool IsOnlyMinus(char keyChar)
        {
            if (minValTextBox.Text.Length == 0 && keyChar == '-')
            {
                return true;
            }
            return false;
        }

        private bool IsValidChar(char keyChar)
        {
            if (IsOnlyMinus(keyChar) && !IsValidNum(keyChar))
            {
                return false;
            }
            return true;
        }

        private bool IsEmptyText(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return true;
            }
            return false;
        }

        private void minValTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!IsValidChar(e.KeyChar))
            {
                _isInvalid = true;
                e.Handled = true;
            }
        }

        private void minValTextBox_TextChanged(object sender, EventArgs e)
        {
            if (_isInvalid || IsEmptyText(minValTextBox.Text) || IsEmptyText(maxValueTextBox.Text))
            {
                return;
            }
            CheckMinBiggerThanMax();
            var res = GetNumType();
            if (res is null)
            {
                suggestedTypeLabel.Text = "";
            }
            else
            {
                suggestedTypeLabel.Text = res;
            }
        }


        private void maxValueTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!IsValidChar(e.KeyChar))
            {
                _isInvalid = true;
                e.Handled = true;
            }
        }

        private void maxValueTextBox_TextChanged(object sender, EventArgs e)
        {
            if (_isInvalid || IsEmptyText(maxValueTextBox.Text) || IsEmptyText(minValTextBox.Text))
            {
                return;
            }
            CheckMinBiggerThanMax();
            var res = GetNumType();
            if (res is null)
            {
                suggestedTypeLabel.Text = "";
            }
            else
            {
                suggestedTypeLabel.Text = res;
            }
        }


        private void integralOnlyCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (integralOnlyCheckBox.Checked)
            {
                preciseLabel.Visible = false;
                preciseCheckBox.Visible = false;
                return;
            }
            preciseLabel.Visible = true;
            preciseCheckBox.Visible = true;
        }
    }
}
