namespace EvolutionDemographique.formulaire
{
    partial class Login
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
            this.TextUser = new MaterialSkin.Controls.MaterialTextBox2();
            this.TextPass = new MaterialSkin.Controls.MaterialTextBox2();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnConnexion = new MaterialSkin.Controls.MaterialButton();
            this.btnQuitter = new MaterialSkin.Controls.MaterialButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // TextUser
            // 
            this.TextUser.AnimateReadOnly = false;
            this.TextUser.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.TextUser.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.TextUser.Depth = 0;
            this.TextUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.TextUser.HideSelection = true;
            this.TextUser.Hint = "Nom Utilisateur";
            this.TextUser.LeadingIcon = null;
            this.TextUser.Location = new System.Drawing.Point(47, 295);
            this.TextUser.MaxLength = 32767;
            this.TextUser.MouseState = MaterialSkin.MouseState.OUT;
            this.TextUser.Name = "TextUser";
            this.TextUser.PasswordChar = '\0';
            this.TextUser.PrefixSuffixText = null;
            this.TextUser.ReadOnly = false;
            this.TextUser.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.TextUser.SelectedText = "";
            this.TextUser.SelectionLength = 0;
            this.TextUser.SelectionStart = 0;
            this.TextUser.ShortcutsEnabled = true;
            this.TextUser.Size = new System.Drawing.Size(248, 48);
            this.TextUser.TabIndex = 6;
            this.TextUser.TabStop = false;
            this.TextUser.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.TextUser.TrailingIcon = null;
            this.TextUser.UseSystemPasswordChar = false;
            // 
            // TextPass
            // 
            this.TextPass.AnimateReadOnly = false;
            this.TextPass.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.TextPass.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.TextPass.Depth = 0;
            this.TextPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.TextPass.HideSelection = true;
            this.TextPass.Hint = "Password";
            this.TextPass.LeadingIcon = null;
            this.TextPass.Location = new System.Drawing.Point(47, 378);
            this.TextPass.MaxLength = 32767;
            this.TextPass.MouseState = MaterialSkin.MouseState.OUT;
            this.TextPass.Name = "TextPass";
            this.TextPass.PasswordChar = '.';
            this.TextPass.PrefixSuffixText = null;
            this.TextPass.ReadOnly = false;
            this.TextPass.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.TextPass.SelectedText = "";
            this.TextPass.SelectionLength = 0;
            this.TextPass.SelectionStart = 0;
            this.TextPass.ShortcutsEnabled = true;
            this.TextPass.Size = new System.Drawing.Size(248, 48);
            this.TextPass.TabIndex = 7;
            this.TextPass.TabStop = false;
            this.TextPass.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.TextPass.TrailingIcon = null;
            this.TextPass.UseSystemPasswordChar = false;
            // 
            // materialLabel1
            // 
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(73)))), ((int)(((byte)(85)))));
            this.materialLabel1.Location = new System.Drawing.Point(90, 242);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(153, 50);
            this.materialLabel1.TabIndex = 8;
            this.materialLabel1.Text = "Login";
            this.materialLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(32, 32);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::EvolutionDemographique.Properties.Resources.images__1__removebg_preview;
            this.pictureBox1.Location = new System.Drawing.Point(90, 67);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(153, 172);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // btnConnexion
            // 
            this.btnConnexion.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnConnexion.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnConnexion.Depth = 0;
            this.btnConnexion.HighEmphasis = true;
            this.btnConnexion.Icon = null;
            this.btnConnexion.Location = new System.Drawing.Point(47, 456);
            this.btnConnexion.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnConnexion.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnConnexion.Name = "btnConnexion";
            this.btnConnexion.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnConnexion.Size = new System.Drawing.Size(105, 36);
            this.btnConnexion.TabIndex = 9;
            this.btnConnexion.Text = "Connexion";
            this.btnConnexion.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnConnexion.UseAccentColor = false;
            this.btnConnexion.UseVisualStyleBackColor = true;
            this.btnConnexion.Click += new System.EventHandler(this.materialButton1_Click);
            // 
            // btnQuitter
            // 
            this.btnQuitter.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnQuitter.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnQuitter.Depth = 0;
            this.btnQuitter.HighEmphasis = true;
            this.btnQuitter.Icon = null;
            this.btnQuitter.Location = new System.Drawing.Point(190, 456);
            this.btnQuitter.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnQuitter.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnQuitter.Name = "btnQuitter";
            this.btnQuitter.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnQuitter.Size = new System.Drawing.Size(81, 36);
            this.btnQuitter.TabIndex = 10;
            this.btnQuitter.Text = "Quitter";
            this.btnQuitter.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnQuitter.UseAccentColor = false;
            this.btnQuitter.UseVisualStyleBackColor = true;
            this.btnQuitter.Click += new System.EventHandler(this.btnQuitter_Click);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.ClientSize = new System.Drawing.Size(332, 522);
            this.Controls.Add(this.btnQuitter);
            this.Controls.Add(this.btnConnexion);
            this.Controls.Add(this.materialLabel1);
            this.Controls.Add(this.TextPass);
            this.Controls.Add(this.TextUser);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Authentification";
            this.Load += new System.EventHandler(this.Login_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private MaterialSkin.Controls.MaterialTextBox2 TextUser;
        private MaterialSkin.Controls.MaterialTextBox2 TextPass;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private System.Windows.Forms.ImageList imageList1;
        private MaterialSkin.Controls.MaterialButton btnConnexion;
        private MaterialSkin.Controls.MaterialButton btnQuitter;

    }
}