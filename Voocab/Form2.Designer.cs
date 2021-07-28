
namespace Voocab
{
    partial class Form2
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.tbDenumire = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbExplicatie = new System.Windows.Forms.TextBox();
            this.btAdaugare = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Product Sans", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(32, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cuvant nou:";
            // 
            // tbDenumire
            // 
            this.tbDenumire.BackColor = System.Drawing.SystemColors.Menu;
            this.tbDenumire.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbDenumire.Font = new System.Drawing.Font("Product Sans", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbDenumire.Location = new System.Drawing.Point(156, 81);
            this.tbDenumire.Name = "tbDenumire";
            this.tbDenumire.Size = new System.Drawing.Size(231, 31);
            this.tbDenumire.TabIndex = 2;
            this.tbDenumire.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Product Sans", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(45, 119);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "Explicatie";
            // 
            // tbExplicatie
            // 
            this.tbExplicatie.BackColor = System.Drawing.SystemColors.Menu;
            this.tbExplicatie.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbExplicatie.Font = new System.Drawing.Font("Product Sans", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbExplicatie.Location = new System.Drawing.Point(156, 119);
            this.tbExplicatie.Multiline = true;
            this.tbExplicatie.Name = "tbExplicatie";
            this.tbExplicatie.Size = new System.Drawing.Size(231, 104);
            this.tbExplicatie.TabIndex = 2;
            this.tbExplicatie.TabStop = false;
            // 
            // btAdaugare
            // 
            this.btAdaugare.Font = new System.Drawing.Font("Product Sans", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btAdaugare.Location = new System.Drawing.Point(156, 263);
            this.btAdaugare.Name = "btAdaugare";
            this.btAdaugare.Size = new System.Drawing.Size(123, 48);
            this.btAdaugare.TabIndex = 4;
            this.btAdaugare.Text = "Adauga";
            this.btAdaugare.UseVisualStyleBackColor = true;
            this.btAdaugare.Click += new System.EventHandler(this.btAdaugare_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Voocab.Properties.Resources.vocab_logo;
            this.pictureBox1.Location = new System.Drawing.Point(11, 11);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(151, 38);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(428, 364);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btAdaugare);
            this.Controls.Add(this.tbExplicatie);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbDenumire);
            this.Controls.Add(this.label1);
            this.KeyPreview = true;
            this.Name = "Form2";
            this.ShowIcon = false;
            this.Text = "Form2";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbDenumire;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbExplicatie;
        private System.Windows.Forms.Button btAdaugare;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}