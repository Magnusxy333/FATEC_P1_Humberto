<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Estoque
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Estoque))
        Me.Label5 = New System.Windows.Forms.Label()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.txt_buscar = New System.Windows.Forms.ToolStripTextBox()
        Me.ToolStripLabel2 = New System.Windows.Forms.ToolStripLabel()
        Me.cmd_campo = New System.Windows.Forms.ToolStripComboBox()
        Me.dgv_estoqueDados = New System.Windows.Forms.DataGridView()
        Me.btn_entrada = New System.Windows.Forms.DataGridViewImageColumn()
        Me.btn_saida = New System.Windows.Forms.DataGridViewImageColumn()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.AdicionarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CadastroDeProdutoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ConsultaDeProdutoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.VendasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.dgv_estoqueDados, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 27.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(109, 76)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(504, 42)
        Me.Label5.TabIndex = 21
        Me.Label5.Text = "Gerênciamento de estoque "
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel1, Me.txt_buscar, Me.ToolStripLabel2, Me.cmd_campo})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 24)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(800, 25)
        Me.ToolStrip1.TabIndex = 20
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(117, 22)
        Me.ToolStripLabel1.Text = "selecione parâmetro "
        '
        'txt_buscar
        '
        Me.txt_buscar.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txt_buscar.Name = "txt_buscar"
        Me.txt_buscar.Size = New System.Drawing.Size(100, 25)
        '
        'ToolStripLabel2
        '
        Me.ToolStripLabel2.Name = "ToolStripLabel2"
        Me.ToolStripLabel2.Size = New System.Drawing.Size(106, 22)
        Me.ToolStripLabel2.Text = "selecione o campo"
        '
        'cmd_campo
        '
        Me.cmd_campo.Name = "cmd_campo"
        Me.cmd_campo.Size = New System.Drawing.Size(121, 25)
        '
        'dgv_estoqueDados
        '
        Me.dgv_estoqueDados.AllowUserToAddRows = False
        Me.dgv_estoqueDados.AllowUserToDeleteRows = False
        Me.dgv_estoqueDados.BackgroundColor = System.Drawing.SystemColors.InactiveCaption
        Me.dgv_estoqueDados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_estoqueDados.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.btn_entrada, Me.btn_saida})
        Me.dgv_estoqueDados.GridColor = System.Drawing.Color.DarkSlateGray
        Me.dgv_estoqueDados.Location = New System.Drawing.Point(20, 135)
        Me.dgv_estoqueDados.Name = "dgv_estoqueDados"
        Me.dgv_estoqueDados.Size = New System.Drawing.Size(768, 303)
        Me.dgv_estoqueDados.TabIndex = 19
        '
        'btn_entrada
        '
        Me.btn_entrada.HeaderText = "Adicionar"
        Me.btn_entrada.Image = CType(resources.GetObject("btn_entrada.Image"), System.Drawing.Image)
        Me.btn_entrada.Name = "btn_entrada"
        Me.btn_entrada.ReadOnly = True
        Me.btn_entrada.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.btn_entrada.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'btn_saida
        '
        Me.btn_saida.HeaderText = "Remover"
        Me.btn_saida.Image = CType(resources.GetObject("btn_saida.Image"), System.Drawing.Image)
        Me.btn_saida.Name = "btn_saida"
        Me.btn_saida.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.btn_saida.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'MenuStrip1
        '
        Me.MenuStrip1.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AdicionarToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(800, 24)
        Me.MenuStrip1.TabIndex = 18
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'AdicionarToolStripMenuItem
        '
        Me.AdicionarToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CadastroDeProdutoToolStripMenuItem, Me.ConsultaDeProdutoToolStripMenuItem, Me.VendasToolStripMenuItem})
        Me.AdicionarToolStripMenuItem.Image = CType(resources.GetObject("AdicionarToolStripMenuItem.Image"), System.Drawing.Image)
        Me.AdicionarToolStripMenuItem.Name = "AdicionarToolStripMenuItem"
        Me.AdicionarToolStripMenuItem.Size = New System.Drawing.Size(66, 20)
        Me.AdicionarToolStripMenuItem.Text = "Menu"
        '
        'CadastroDeProdutoToolStripMenuItem
        '
        Me.CadastroDeProdutoToolStripMenuItem.Image = CType(resources.GetObject("CadastroDeProdutoToolStripMenuItem.Image"), System.Drawing.Image)
        Me.CadastroDeProdutoToolStripMenuItem.Name = "CadastroDeProdutoToolStripMenuItem"
        Me.CadastroDeProdutoToolStripMenuItem.Size = New System.Drawing.Size(183, 22)
        Me.CadastroDeProdutoToolStripMenuItem.Text = "Cadastro de produto"
        '
        'ConsultaDeProdutoToolStripMenuItem
        '
        Me.ConsultaDeProdutoToolStripMenuItem.Image = CType(resources.GetObject("ConsultaDeProdutoToolStripMenuItem.Image"), System.Drawing.Image)
        Me.ConsultaDeProdutoToolStripMenuItem.Name = "ConsultaDeProdutoToolStripMenuItem"
        Me.ConsultaDeProdutoToolStripMenuItem.Size = New System.Drawing.Size(183, 22)
        Me.ConsultaDeProdutoToolStripMenuItem.Text = "Consulta de produto"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(619, 61)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(65, 57)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 22
        Me.PictureBox1.TabStop = False
        '
        'VendasToolStripMenuItem
        '
        Me.VendasToolStripMenuItem.Image = CType(resources.GetObject("VendasToolStripMenuItem.Image"), System.Drawing.Image)
        Me.VendasToolStripMenuItem.Name = "VendasToolStripMenuItem"
        Me.VendasToolStripMenuItem.Size = New System.Drawing.Size(183, 22)
        Me.VendasToolStripMenuItem.Text = "Vendas"
        '
        'Estoque
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.SlateGray
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.dgv_estoqueDados)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Name = "Estoque"
        Me.Text = "Genrenciador"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.dgv_estoqueDados, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label5 As Label
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents ToolStripLabel1 As ToolStripLabel
    Friend WithEvents txt_buscar As ToolStripTextBox
    Friend WithEvents ToolStripLabel2 As ToolStripLabel
    Friend WithEvents cmd_campo As ToolStripComboBox
    Friend WithEvents dgv_estoqueDados As DataGridView
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents AdicionarToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CadastroDeProdutoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ConsultaDeProdutoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents btn_entrada As DataGridViewImageColumn
    Friend WithEvents btn_saida As DataGridViewImageColumn
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents VendasToolStripMenuItem As ToolStripMenuItem
End Class
