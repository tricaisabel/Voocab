
namespace Voocab
{
    partial class ControlExplicatie
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tbNume = new System.Windows.Forms.TextBox();
            this.tbData = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbExplicatie = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbLikes = new System.Windows.Forms.TextBox();
            this.btLike = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbNume
            // 
            this.tbNume.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.tbNume.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbNume.Font = new System.Drawing.Font("Product Sans", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbNume.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.tbNume.Location = new System.Drawing.Point(3, 5);
            this.tbNume.Name = "tbNume";
            this.tbNume.ReadOnly = true;
            this.tbNume.Size = new System.Drawing.Size(43, 20);
            this.tbNume.TabIndex = 1;
            this.tbNume.TabStop = false;
            // 
            // tbData
            // 
            this.tbData.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.tbData.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbData.Font = new System.Drawing.Font("Product Sans", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbData.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.tbData.Location = new System.Drawing.Point(77, 4);
            this.tbData.Name = "tbData";
            this.tbData.ReadOnly = true;
            this.tbData.Size = new System.Drawing.Size(80, 20);
            this.tbData.TabIndex = 4;
            this.tbData.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Product Sans", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.label2.Location = new System.Drawing.Point(52, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "on";
            // 
            // tbExplicatie
            // 
            this.tbExplicatie.BackColor = System.Drawing.SystemColors.Menu;
            this.tbExplicatie.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbExplicatie.Font = new System.Drawing.Font("Product Sans", 9.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbExplicatie.Location = new System.Drawing.Point(0, 20);
            this.tbExplicatie.Multiline = true;
            this.tbExplicatie.Name = "tbExplicatie";
            this.tbExplicatie.ReadOnly = true;
            this.tbExplicatie.Size = new System.Drawing.Size(205, 23);
            this.tbExplicatie.TabIndex = 5;
            this.tbExplicatie.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Product Sans", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.label1.Location = new System.Drawing.Point(42, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 20);
            this.label1.TabIndex = 8;
            this.label1.Text = "Likes";
            // 
            // tbLikes
            // 
            this.tbLikes.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.tbLikes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbLikes.Font = new System.Drawing.Font("Product Sans", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbLikes.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.tbLikes.Location = new System.Drawing.Point(25, 44);
            this.tbLikes.Name = "tbLikes";
            this.tbLikes.ReadOnly = true;
            this.tbLikes.Size = new System.Drawing.Size(20, 20);
            this.tbLikes.TabIndex = 7;
            this.tbLikes.TabStop = false;
            // 
            // btLike
            // 
            this.btLike.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btLike.Font = new System.Drawing.Font("Product Sans", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btLike.Location = new System.Drawing.Point(155, 44);
            this.btLike.Name = "btLike";
            this.btLike.Size = new System.Drawing.Size(51, 20);
            this.btLike.TabIndex = 6;
            this.btLike.Text = "Like";
            this.btLike.UseVisualStyleBackColor = false;
            this.btLike.Click += new System.EventHandler(this.btLike_Click);
            // 
            // ControlExplicatie
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbLikes);
            this.Controls.Add(this.btLike);
            this.Controls.Add(this.tbExplicatie);
            this.Controls.Add(this.tbData);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbNume);
            this.Name = "ControlExplicatie";
            this.Size = new System.Drawing.Size(218, 77);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox tbNume;
        private System.Windows.Forms.TextBox tbData;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbExplicatie;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbLikes;
        private System.Windows.Forms.Button btLike;
    }
}
