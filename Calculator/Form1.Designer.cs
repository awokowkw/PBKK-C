namespace CalculatorApp
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        private PictureBox picMascot;
        private Label lblTitle;
        private TextBox txtDisplay;
        private Button btnBackspace;

        private Button btn7;
        private Button btn8;
        private Button btn9;
        private Button btnDivide;

        private Button btn4;
        private Button btn5;
        private Button btn6;
        private Button btnMultiply;

        private Button btn1;
        private Button btn2;
        private Button btn3;
        private Button btnMinus;

        private Button btn0;
        private Button btnDecimal;
        private Button btnClear;
        private Button btnPlus;

        private Button btnEquals;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();

            picMascot = new PictureBox();
            lblTitle = new Label();
            txtDisplay = new TextBox();
            btnBackspace = new Button();

            btn7 = new Button();
            btn8 = new Button();
            btn9 = new Button();
            btnDivide = new Button();

            btn4 = new Button();
            btn5 = new Button();
            btn6 = new Button();
            btnMultiply = new Button();

            btn1 = new Button();
            btn2 = new Button();
            btn3 = new Button();
            btnMinus = new Button();

            btn0 = new Button();
            btnDecimal = new Button();
            btnClear = new Button();
            btnPlus = new Button();

            btnEquals = new Button();

            ((System.ComponentModel.ISupportInitialize)picMascot).BeginInit();
            SuspendLayout();

            Color colorBackground = Color.FromArgb(255, 255, 255);   // bulu putih
            Color colorTitle = Color.FromArgb(90, 60, 90);           // ungu gelap lembut
            Color colorDisplayBack = Color.FromArgb(245, 245, 248);
            Color colorDisplayText = Color.FromArgb(43, 43, 43);     // hitam outline
            Color colorNumberBack = Color.FromArgb(217, 220, 227);   // abu bayangan bulu
            Color colorNumberText = Color.FromArgb(60, 60, 70);
            Color colorOperatorBack = Color.FromArgb(109, 76, 65);   // cokelat telinga/ekor
            Color colorOperatorText = Color.FromArgb(255, 255, 255);
            Color colorClearBack = Color.FromArgb(41, 121, 226);     // biru mata
            Color colorClearText = Color.FromArgb(255, 255, 255);
            Color colorEqualsBack = Color.FromArgb(230, 0, 126);     // magenta outline
            Color colorEqualsText = Color.FromArgb(255, 255, 255);

            BackColor = colorBackground;

            picMascot.Location = new Point(125, 15);
            picMascot.Name = "picMascot";
            picMascot.Size = new Size(110, 110);
            picMascot.SizeMode = PictureBoxSizeMode.Zoom;
            picMascot.BackColor = Color.Transparent;
            try
            {
                string imagePath = Path.Combine(AppContext.BaseDirectory, "Assets", "IMG_1011.PNG");
                if (File.Exists(imagePath))
                {
                    byte[] imageBytes = File.ReadAllBytes(imagePath);
                    using (MemoryStream ms = new MemoryStream(imageBytes))
                    {
                        picMascot.Image = Image.FromStream(ms);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal load gambar: " + ex.Message, "Debug");
            }

            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitle.ForeColor = colorTitle;
            lblTitle.Location = new Point(105, 120);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(160, 30);
            lblTitle.Text = "Kalkulator";

            txtDisplay.Font = new Font("Segoe UI", 20F);
            txtDisplay.BackColor = colorDisplayBack;
            txtDisplay.ForeColor = colorDisplayText;
            txtDisplay.BorderStyle = BorderStyle.FixedSingle;
            txtDisplay.Location = new Point(25, 165);
            txtDisplay.Name = "txtDisplay";
            txtDisplay.ReadOnly = true;
            txtDisplay.Size = new Size(250, 43);
            txtDisplay.Text = "0";
            txtDisplay.TextAlign = HorizontalAlignment.Right;

            btnBackspace.Location = new Point(285, 165);
            btnBackspace.Name = "btnBackspace";
            btnBackspace.Size = new Size(60, 43);
            btnBackspace.Text = "⌫";
            btnBackspace.UseVisualStyleBackColor = true;
            btnBackspace.Click += btnBackspace_Click;

            btn7.Location = new Point(25, 225);
            btn7.Name = "btn7";
            btn7.Size = new Size(70, 50);
            btn7.Text = "7";
            btn7.UseVisualStyleBackColor = true;
            btn7.Click += NumberButton_Click;

            btn8.Location = new Point(105, 225);
            btn8.Name = "btn8";
            btn8.Size = new Size(70, 50);
            btn8.Text = "8";
            btn8.UseVisualStyleBackColor = true;
            btn8.Click += NumberButton_Click;

            btn9.Location = new Point(185, 225);
            btn9.Name = "btn9";
            btn9.Size = new Size(70, 50);
            btn9.Text = "9";
            btn9.UseVisualStyleBackColor = true;
            btn9.Click += NumberButton_Click;

            btnDivide.Location = new Point(275, 225);
            btnDivide.Name = "btnDivide";
            btnDivide.Size = new Size(70, 50);
            btnDivide.Text = "÷";
            btnDivide.UseVisualStyleBackColor = true;
            btnDivide.Click += OperatorButton_Click;

            btn4.Location = new Point(25, 285);
            btn4.Name = "btn4";
            btn4.Size = new Size(70, 50);
            btn4.Text = "4";
            btn4.UseVisualStyleBackColor = true;
            btn4.Click += NumberButton_Click;

            btn5.Location = new Point(105, 285);
            btn5.Name = "btn5";
            btn5.Size = new Size(70, 50);
            btn5.Text = "5";
            btn5.UseVisualStyleBackColor = true;
            btn5.Click += NumberButton_Click;

            btn6.Location = new Point(185, 285);
            btn6.Name = "btn6";
            btn6.Size = new Size(70, 50);
            btn6.Text = "6";
            btn6.UseVisualStyleBackColor = true;
            btn6.Click += NumberButton_Click;

            btnMultiply.Location = new Point(275, 285);
            btnMultiply.Name = "btnMultiply";
            btnMultiply.Size = new Size(70, 50);
            btnMultiply.Text = "×";
            btnMultiply.UseVisualStyleBackColor = true;
            btnMultiply.Click += OperatorButton_Click;

            btn1.Location = new Point(25, 345);
            btn1.Name = "btn1";
            btn1.Size = new Size(70, 50);
            btn1.Text = "1";
            btn1.UseVisualStyleBackColor = true;
            btn1.Click += NumberButton_Click;

            btn2.Location = new Point(105, 345);
            btn2.Name = "btn2";
            btn2.Size = new Size(70, 50);
            btn2.Text = "2";
            btn2.UseVisualStyleBackColor = true;
            btn2.Click += NumberButton_Click;

            btn3.Location = new Point(185, 345);
            btn3.Name = "btn3";
            btn3.Size = new Size(70, 50);
            btn3.Text = "3";
            btn3.UseVisualStyleBackColor = true;
            btn3.Click += NumberButton_Click;

            btnMinus.Location = new Point(275, 345);
            btnMinus.Name = "btnMinus";
            btnMinus.Size = new Size(70, 50);
            btnMinus.Text = "−";
            btnMinus.UseVisualStyleBackColor = true;
            btnMinus.Click += OperatorButton_Click;

            btn0.Location = new Point(25, 405);
            btn0.Name = "btn0";
            btn0.Size = new Size(70, 50);
            btn0.Text = "0";
            btn0.UseVisualStyleBackColor = true;
            btn0.Click += NumberButton_Click;

            btnDecimal.Location = new Point(105, 405);
            btnDecimal.Name = "btnDecimal";
            btnDecimal.Size = new Size(70, 50);
            btnDecimal.Text = ".";
            btnDecimal.UseVisualStyleBackColor = true;
            btnDecimal.Click += btnDecimal_Click;

            btnClear.Location = new Point(185, 405);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(70, 50);
            btnClear.Text = "C";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;

            btnPlus.Location = new Point(275, 405);
            btnPlus.Name = "btnPlus";
            btnPlus.Size = new Size(70, 50);
            btnPlus.Text = "+";
            btnPlus.UseVisualStyleBackColor = true;
            btnPlus.Click += OperatorButton_Click;

            btnEquals.Location = new Point(25, 465);
            btnEquals.Name = "btnEquals";
            btnEquals.Size = new Size(320, 50);
            btnEquals.Text = "=";
            btnEquals.UseVisualStyleBackColor = true;
            btnEquals.Click += btnEquals_Click;

            Button[] numberButtons = { btn0, btn1, btn2, btn3, btn4, btn5, btn6, btn7, btn8, btn9 };
            foreach (Button btn in numberButtons)
            {
                btn.Font = new Font("Segoe UI", 12F, FontStyle.Regular);
                btn.BackColor = colorNumberBack;
                btn.ForeColor = colorNumberText;
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 0;
                btn.Cursor = Cursors.Hand;
            }

            Button[] operatorButtons = { btnPlus, btnMinus, btnMultiply, btnDivide };
            foreach (Button btn in operatorButtons)
            {
                btn.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
                btn.BackColor = colorOperatorBack;
                btn.ForeColor = colorOperatorText;
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 0;
                btn.Cursor = Cursors.Hand;
            }

            btnDecimal.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            btnDecimal.BackColor = colorNumberBack;
            btnDecimal.ForeColor = colorNumberText;
            btnDecimal.FlatStyle = FlatStyle.Flat;
            btnDecimal.FlatAppearance.BorderSize = 0;
            btnDecimal.Cursor = Cursors.Hand;

            btnClear.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnClear.BackColor = colorClearBack;
            btnClear.ForeColor = colorClearText;
            btnClear.FlatStyle = FlatStyle.Flat;
            btnClear.FlatAppearance.BorderSize = 0;
            btnClear.Cursor = Cursors.Hand;

            btnBackspace.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            btnBackspace.BackColor = colorClearBack;
            btnBackspace.ForeColor = colorClearText;
            btnBackspace.FlatStyle = FlatStyle.Flat;
            btnBackspace.FlatAppearance.BorderSize = 0;
            btnBackspace.Cursor = Cursors.Hand;

            btnEquals.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            btnEquals.BackColor = colorEqualsBack;
            btnEquals.ForeColor = colorEqualsText;
            btnEquals.FlatStyle = FlatStyle.Flat;
            btnEquals.FlatAppearance.BorderSize = 0;
            btnEquals.Cursor = Cursors.Hand;

            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(370, 540);

            Controls.Add(picMascot);
            Controls.Add(lblTitle);
            Controls.Add(txtDisplay);
            Controls.Add(btnBackspace);

            Controls.Add(btn7);
            Controls.Add(btn8);
            Controls.Add(btn9);
            Controls.Add(btnDivide);

            Controls.Add(btn4);
            Controls.Add(btn5);
            Controls.Add(btn6);
            Controls.Add(btnMultiply);

            Controls.Add(btn1);
            Controls.Add(btn2);
            Controls.Add(btn3);
            Controls.Add(btnMinus);

            Controls.Add(btn0);
            Controls.Add(btnDecimal);
            Controls.Add(btnClear);
            Controls.Add(btnPlus);

            Controls.Add(btnEquals);

            Name = "Form1";
            Text = "Kalkulator";
            StartPosition = FormStartPosition.CenterScreen;

            ((System.ComponentModel.ISupportInitialize)picMascot).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
