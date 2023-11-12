namespace EmpresaApi.Models;

public partial class Empresa
{
    public string Cnpj { get; set; } = null!;

    public string RazaoSocial { get; set; } = null!;

    public string NomeFantasia { get; set; }

    public bool SituacaoCadastral { get; set; }

    public string Telefone { get; set; } = null!;

    public string Cidade { get; set; } = null!;

    public string Uf { get; set; } = null!;

    public string Cep { get; set; } = null!;

    public string Logradouro { get; set; } = null!;

    public string Numero { get; set; }

}
