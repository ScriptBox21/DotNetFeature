namespace Lab05_Event
{
    partial class Form3
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다.
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            this.myButton1 = new Lab05_Event.MyButton();
            this.userControl21 = new Lab05_Event.UserControl2();
            this.SuspendLayout();
            // 
            // myButton1
            // 
            this.myButton1.Location = new System.Drawing.Point(127, 107);
            this.myButton1.Name = "myButton1";
            this.myButton1.Size = new System.Drawing.Size(75, 23);
            this.myButton1.TabIndex = 1;
            this.myButton1.Text = "myButton1";
            this.myButton1.UseVisualStyleBackColor = true;
            // 
            // userControl21
            // 
            this.userControl21.Location = new System.Drawing.Point(61, 65);
            this.userControl21.Name = "userControl21";
            this.userControl21.Size = new System.Drawing.Size(150, 20);
            this.userControl21.TabIndex = 0;
            this.userControl21.AfterSelectedIndexChanged += new Lab05_Event.AfterSelectedIndexChangedEventHandler(this.userControl21_AfterSelectedIndexChanged);
            this.userControl21.BeforeSelectedIndexChanged += new Lab05_Event.BeforeSelectedIndexChangedEventHandler(this.userControl21_BeforeSelectedIndexChanged);
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 273);
            this.Controls.Add(this.myButton1);
            this.Controls.Add(this.userControl21);
            this.Name = "Form3";
            this.Text = "Form3";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form3_Paint);
            this.Shown += new System.EventHandler(this.Form3_Shown);
            this.Load += new System.EventHandler(this.Form3_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private UserControl2 userControl21;
        private MyButton myButton1;
    }
}