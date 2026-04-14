<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Cadastro
    Inherits System.Windows.Forms.Form

    'Descartar substituições de formulário para limpar a lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Exigido pelo Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'OBSERVAÇÃO: o procedimento a seguir é exigido pelo Windows Form Designer
    'Pode ser modificado usando o Windows Form Designer.  
    'Não o modifique usando o editor de códigos.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Cadastro))
        Me.desc_produto_text = New System.Windows.Forms.TextBox()
        Me.qnt_dis_prod_text = New System.Windows.Forms.TextBox()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.preco_cust_text = New System.Windows.Forms.TextBox()
        Me.preco_venda_text = New System.Windows.Forms.TextBox()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.bnt_gravar = New System.Windows.Forms.ToolStripButton()
        Me.categoria_produto_cmd = New System.Windows.Forms.ComboBox()
        Me.marca_produto_cmd = New System.Windows.Forms.ComboBox()
        Me.data_lote_date = New System.Windows.Forms.DateTimePicker()
        Me.label = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.foto_prod_pic = New System.Windows.Forms.PictureBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.foto_prod_pic, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'desc_produto_text
        '
        Me.desc_produto_text.Font = New System.Drawing.Font("Microsoft YaHei", 9.75!)
        Me.desc_produto_text.Location = New System.Drawing.Point(73, 205)
        Me.desc_produto_text.Name = "desc_produto_text"
        Me.desc_produto_text.Size = New System.Drawing.Size(213, 25)
        Me.desc_produto_text.TabIndex = 0
        '
        'qnt_dis_prod_text
        '
        Me.qnt_dis_prod_text.Font = New System.Drawing.Font("Microsoft YaHei", 9.75!)
        Me.qnt_dis_prod_text.Location = New System.Drawing.Point(73, 260)
        Me.qnt_dis_prod_text.Name = "qnt_dis_prod_text"
        Me.qnt_dis_prod_text.Size = New System.Drawing.Size(213, 25)
        Me.qnt_dis_prod_text.TabIndex = 1
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(61, 4)
        '
        'preco_cust_text
        '
        Me.preco_cust_text.Font = New System.Drawing.Font("Microsoft YaHei", 9.75!)
        Me.preco_cust_text.Location = New System.Drawing.Point(73, 316)
        Me.preco_cust_text.Name = "preco_cust_text"
        Me.preco_cust_text.Size = New System.Drawing.Size(214, 25)
        Me.preco_cust_text.TabIndex = 3
        '
        'preco_venda_text
        '
        Me.preco_venda_text.Font = New System.Drawing.Font("Microsoft YaHei", 9.75!)
        Me.preco_venda_text.Location = New System.Drawing.Point(73, 378)
        Me.preco_venda_text.Name = "preco_venda_text"
        Me.preco_venda_text.Size = New System.Drawing.Size(214, 25)
        Me.preco_venda_text.TabIndex = 4
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.bnt_gravar})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(949, 25)
        Me.ToolStrip1.TabIndex = 5
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'bnt_gravar
        '
        Me.bnt_gravar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.bnt_gravar.Image = Global.CarsKHATUA.My.Resources.Resources.gravar
        Me.bnt_gravar.ImageTransparentColor = System.Drawing.Color.Transparent
        Me.bnt_gravar.Name = "bnt_gravar"
        Me.bnt_gravar.Size = New System.Drawing.Size(23, 22)
        Me.bnt_gravar.Text = "ToolStripButton1"
        '
        'categoria_produto_cmd
        '
        Me.categoria_produto_cmd.Font = New System.Drawing.Font("Microsoft YaHei", 9.75!)
        Me.categoria_produto_cmd.FormattingEnabled = True
        Me.categoria_produto_cmd.Items.AddRange(New Object() {"Parachoque", "Lanterna", "Placa", "Freios", "Pneus"})
        Me.categoria_produto_cmd.Location = New System.Drawing.Point(372, 205)
        Me.categoria_produto_cmd.Name = "categoria_produto_cmd"
        Me.categoria_produto_cmd.Size = New System.Drawing.Size(230, 27)
        Me.categoria_produto_cmd.TabIndex = 6
        '
        'marca_produto_cmd
        '
        Me.marca_produto_cmd.Font = New System.Drawing.Font("Microsoft YaHei", 9.75!)
        Me.marca_produto_cmd.FormattingEnabled = True
        Me.marca_produto_cmd.Items.AddRange(New Object() {"Hyundai", "Toyota", "Honda", "Fiat", "Volkswagem", "BYD", "Ford"})
        Me.marca_produto_cmd.Location = New System.Drawing.Point(372, 258)
        Me.marca_produto_cmd.Name = "marca_produto_cmd"
        Me.marca_produto_cmd.Size = New System.Drawing.Size(230, 27)
        Me.marca_produto_cmd.TabIndex = 7
        '
        'data_lote_date
        '
        Me.data_lote_date.Font = New System.Drawing.Font("Microsoft YaHei", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.data_lote_date.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.data_lote_date.Location = New System.Drawing.Point(373, 314)
        Me.data_lote_date.Name = "data_lote_date"
        Me.data_lote_date.Size = New System.Drawing.Size(230, 25)
        Me.data_lote_date.TabIndex = 8
        '
        'label
        '
        Me.label.AutoSize = True
        Me.label.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.label.Location = New System.Drawing.Point(68, 181)
        Me.label.Name = "label"
        Me.label.Size = New System.Drawing.Size(174, 21)
        Me.label.TabIndex = 10
        Me.label.Text = "Descrição do produto"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.Location = New System.Drawing.Point(68, 236)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(190, 21)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "Quantidade do produto"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(68, 354)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(217, 21)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "Preço de venda do produto"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label3.Location = New System.Drawing.Point(369, 235)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(234, 21)
        Me.Label3.TabIndex = 13
        Me.Label3.Text = "Marca/Fabricante do produto"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label4.Location = New System.Drawing.Point(369, 181)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(174, 21)
        Me.Label4.TabIndex = 14
        Me.Label4.Text = "Categoria do produto"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(625, 181)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(312, 39)
        Me.Label5.TabIndex = 15
        Me.Label5.Text = "Adicionar imagem"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(391, 291)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(0, 13)
        Me.Label6.TabIndex = 16
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label7.Location = New System.Drawing.Point(68, 292)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(211, 21)
        Me.Label7.TabIndex = 17
        Me.Label7.Text = "Preço de custo do produto"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(407, 307)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(0, 13)
        Me.Label8.TabIndex = 18
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label9.Location = New System.Drawing.Point(369, 291)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(107, 21)
        Me.Label9.TabIndex = 19
        Me.Label9.Text = "Data do Lote"
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.25!, System.Drawing.FontStyle.Bold)
        Me.Label10.Location = New System.Drawing.Point(329, 68)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(480, 39)
        Me.Label10.TabIndex = 20
        Me.Label10.Text = "Área de cadastro de produto"
        '
        'foto_prod_pic
        '
        Me.foto_prod_pic.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.foto_prod_pic.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.foto_prod_pic.Image = CType(resources.GetObject("foto_prod_pic.Image"), System.Drawing.Image)
        Me.foto_prod_pic.Location = New System.Drawing.Point(678, 258)
        Me.foto_prod_pic.Margin = New System.Windows.Forms.Padding(0)
        Me.foto_prod_pic.Name = "foto_prod_pic"
        Me.foto_prod_pic.Size = New System.Drawing.Size(214, 210)
        Me.foto_prod_pic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.foto_prod_pic.TabIndex = 9
        Me.foto_prod_pic.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(159, 43)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(144, 104)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 21
        Me.PictureBox1.TabStop = False
        '
        'Cadastro
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.SlateGray
        Me.ClientSize = New System.Drawing.Size(949, 520)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.label)
        Me.Controls.Add(Me.foto_prod_pic)
        Me.Controls.Add(Me.data_lote_date)
        Me.Controls.Add(Me.marca_produto_cmd)
        Me.Controls.Add(Me.categoria_produto_cmd)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.preco_venda_text)
        Me.Controls.Add(Me.preco_cust_text)
        Me.Controls.Add(Me.qnt_dis_prod_text)
        Me.Controls.Add(Me.desc_produto_text)
        Me.Name = "Cadastro"
        Me.Text = "Form1"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.foto_prod_pic, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents desc_produto_text As TextBox
    Friend WithEvents qnt_dis_prod_text As TextBox
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents preco_cust_text As TextBox
    Friend WithEvents preco_venda_text As TextBox
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents categoria_produto_cmd As ComboBox
    Friend WithEvents marca_produto_cmd As ComboBox
    Friend WithEvents data_lote_date As DateTimePicker
    Friend WithEvents foto_prod_pic As PictureBox
    Friend WithEvents label As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents bnt_gravar As ToolStripButton
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents Label10 As Label
    Friend WithEvents PictureBox1 As PictureBox
End Class
