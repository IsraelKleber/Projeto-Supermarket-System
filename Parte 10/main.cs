using System; 
using System.Collections.Generic;
using System.Globalization;
using System.Threading;

class  MainClass{ 
  private static NCategoria ncategoria = new NCategoria();
  private static NProduto nproduto = new NProduto();
  private static NCliente ncliente = new NCliente();
  private static Cliente clienteLogin = null;
  
  public static void Main() {
  Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");

    int op = 0;
    int perfil = 0;
    Console.WriteLine("|==== Supermarket System ====|");
    do {
      try{
        if (perfil == 0){
          op = 0;
          perfil = MenuUsuario();
        }
        if (perfil == 1){
          op = MenuVendedor();

            switch (op){
            case 1  : CategoriaListar(); break;
            case 2  : CategoriaInserir(); break;
            case 3  : CategoriaAtualizar(); break;
            case 4  : CategoriaExcluir(); break;
            case 5  : ProdutoListar(); break;
            case 6  : ProdutoInserir(); break;
            case 7  : ProdutoAtualizar(); break;
            case 8  : ProdutoExcluir(); break;
            case 9  : PromocaoListar(); break;
            case 10 : PromocaoInserir(); break;
            case 11 : PromocaoAtualizar(); break;
            case 12 : PromocaoExcluir(); break;
            case 13 : ClienteListar(); break;
            case 14 : ClienteInserir(); break;
            case 15 : ClienteAtualizar(); break;
            case 16 : ClienteExcluir(); break;
            case 99 : perfil = 0; break;
          }
        }
        if (perfil == 2 && clienteLogin == null){
          op = MenuClienteLogin();
          switch (op){
            case 1  : ClienteLogin(); break;
            case 99 : perfil = 0; break;
          }
        }
        if (perfil == 2 && clienteLogin != null){
          op = MenuClienteLogout();
          switch (op){
            case 1  : ClienteVendaListar(); break;
            case 2  : ClienteProdutoListar(); break;
            case 3  : ClienteProdutoInserir(); break;
            case 4  : ClienteCarrinhoVisualizar(); break;
            case 5  : ClienteCarrinhoLimpar(); break;
            case 6  : ClienteCarrinhoComprar(); break;
            case 99 : ClienteLogout(); break;
        }
      }
      }
      catch (Exception erro){
        Console.WriteLine(erro.Message);
        op = 100;
      }
    } while (op != 0);
    Console.WriteLine("Obrigado! Volte sempre!");
  }

  public static int MenuUsuario() {
    Console.WriteLine();
    Console.WriteLine("0 - Sair do sistema!");
    Console.WriteLine("---------------------------------");
    Console.WriteLine("1 - Entrar como vendedor");
    Console.WriteLine("2 - Entrar como Usu??rio");
    Console.WriteLine("---------------------------------");
    Console.Write("Informe o perfil selecionado: ");
    int op = int.Parse(Console.ReadLine());
    Console.WriteLine();
    return op;
  }
  
  public static int MenuVendedor(){
    Console.WriteLine();
    Console.WriteLine("0 - Sair do sistema!");
    Console.WriteLine();
    Console.WriteLine("Categoria: ");
    Console.WriteLine("1 - Listar");
    Console.WriteLine("2 - Inserir");
    Console.WriteLine("3 - Atualizar");
    Console.WriteLine("4 - Excluir");
    Console.WriteLine();
    Console.WriteLine("Produto: ");
    Console.WriteLine("5 - Listar");
    Console.WriteLine("6 - Inserir");
    Console.WriteLine("7 - Atualizar");
    Console.WriteLine("8 - Excluir");
    Console.WriteLine();
    Console.WriteLine("Promo????o: ");
    Console.WriteLine("9  - Listar");
    Console.WriteLine("10 - Inserir");
    Console.WriteLine("11 - Atualizar");
    Console.WriteLine("12 - Excluir");
    Console.WriteLine();
    Console.WriteLine("Cliente: ");
    Console.WriteLine("13 - Listar");
    Console.WriteLine("14 - Inserir");
    Console.WriteLine("15 - Atualizar");
    Console.WriteLine("16 - Excluir");
    Console.WriteLine();
    Console.WriteLine("99 - Voltar ao menu anterior");
    Console.WriteLine();
    Console.Write("Informe a op????o desejada: ");
    int op = int.Parse(Console.ReadLine());
    Console.WriteLine();
    return op;
  }

  public static int MenuClienteLogin(){
    Console.WriteLine();
    Console.WriteLine("0 - Sair do sistema!");
    Console.WriteLine();
    Console.WriteLine("1 - Login");
    Console.WriteLine("99 - Voltar para o menu anterior");
    Console.WriteLine();
    Console.Write("Informe a op????o desejada: ");
    int op = int.Parse(Console.ReadLine());
    Console.WriteLine();
    return op;
  }

  public static int MenuClienteLogout(){
    Console.WriteLine("Bem vindo(a), " + clienteLogin.Nome + "!");
    Console.WriteLine();
    Console.WriteLine("0 - Sair do sistema!");
    Console.WriteLine();
    Console.WriteLine("1 - Listar minhas compras");
    Console.WriteLine("2 - Listar produtos");
    Console.WriteLine("3 - Inserir um produto no carinho");
    Console.WriteLine("4 - Limpar carrinho");
    Console.WriteLine("5 - Limpar o carrinho");
    Console.WriteLine("6 - Confirmar a compra");
    Console.WriteLine("99 - Logout");
    Console.WriteLine();
    Console.Write("Informe a op????o desejada: ");
    int op = int.Parse(Console.ReadLine());
    Console.WriteLine();
    return op;
  }
  public static void CategoriaListar(){
    Console.WriteLine("|==== Lista de Categorias ====|");
    Console.WriteLine();
    Categoria[] cs = ncategoria.Listar();
    if (cs.Length == 0){
      Console.WriteLine("Nenhuma categoria cadastrada");
      return;
    }
    foreach (Categoria c in cs) Console.WriteLine(c);
    Console.WriteLine();

  }
  public static void CategoriaInserir(){
    Console.WriteLine("|==== Inser????o de Categorias ====|");
    Console.WriteLine();
    Console.Write("Informe um c??digo para a categoria: ");
    int id = int.Parse(Console.ReadLine());
    Console.Write("Informe uma descri????o: ");
    string descricao = Console.ReadLine();
    // Instaciar a classe de Categoria
    Categoria c = new Categoria(id, descricao);
    // inser????o da categoria
    ncategoria.Inserir(c);
  }
  public static void CategoriaAtualizar(){
    Console.WriteLine("|==== Atualiza????o de Categorias ====|");
    CategoriaListar();
    Console.Write("Informe o n?? da categoria que deseja atualizar: ");
    int id = int.Parse(Console.ReadLine());
    Console.Write("Informe uma nova descri????o para a categoria: ");
    string descricao = Console.ReadLine();
    // Instaciar a classe de Categoria
    Categoria c = new Categoria(id, descricao);
    // atualizar categoria
    ncategoria.Atualizar(c);

  }
  public static void CategoriaExcluir(){
    Console.WriteLine("|==== Exclus??o de Categorias ====|");
    CategoriaListar();
    Console.Write("Informe o n?? da categoria que deseja excluir: ");
    int id = int.Parse(Console.ReadLine());
    // Instaciar a classe de Categoria
    Categoria c = ncategoria.Listar(id);
    // exclus??o da categoria
    ncategoria.Excluir(c);
  }
  public static void ProdutoListar(){
    Console.WriteLine("|==== Lista de Produtos====|");
    Console.WriteLine();
    Produto[] ps = nproduto.Listar();
    if (ps.Length == 0){
      Console.WriteLine("Nenhum produto cadastrado");
      return;
    }
    foreach (Produto p in ps) Console.WriteLine(p);
    Console.WriteLine();

  }
  public static void ProdutoInserir(){
    Console.WriteLine("|==== Inser????o de Produtos ====|");
    Console.WriteLine();
    Console.Write("Informe um c??digo para o produto: ");
    int id = int.Parse(Console.ReadLine());
    Console.Write("Informe uma descri????o: ");
    string descricao = Console.ReadLine();
    Console.Write("Informe a quantidade do produto no estoque: ");
    int qtd = int.Parse(Console.ReadLine());
    Console.Write("Informe o pre??o do produto: ");
    double preco = double.Parse(Console.ReadLine());
    CategoriaListar();
    Console.Write("informe o n?? de uma das categorias listadas acima: ");
    int idcategoria = int.Parse(Console.ReadLine());
    // Selecionar a categoria a partir do id
    Categoria c = ncategoria.Listar(idcategoria);
    // instanciar a classe de produto
    Produto p = new Produto(id, descricao, qtd, preco, c);
    //Atualizar Produto
    nproduto.Inserir(p);
  }
  public static void ProdutoAtualizar(){
    Console.WriteLine("|==== Atualiza????o de Produtos ====|");
    Console.WriteLine();
    ProdutoListar();
    Console.Write("Informe o n?? do produto que deseja atualizar: ");
    int id = int.Parse(Console.ReadLine());
    Console.Write("Informe uma descri????o: ");
    string descricao = Console.ReadLine();
    Console.Write("Informe a quantidade do produto no estoque: ");
    int qtd = int.Parse(Console.ReadLine());
    Console.Write("Informe o pre??o do produto: ");
    double preco = double.Parse(Console.ReadLine());
    CategoriaListar();
    Console.Write("informe o n?? de uma das categorias listadas acima: ");
    int idcategoria = int.Parse(Console.ReadLine());
    // Selecionar a categoria a partir do id
    Categoria c = ncategoria.Listar(idcategoria);
    // instanciar a classe de produto
    Produto p = new Produto(id, descricao, qtd, preco, c);
    //inser????o do Produto
    nproduto.Atualizar(p);
  }
  public static void ProdutoExcluir(){
    Console.WriteLine("|==== Exclus??o de Produtos ====|");
    Console.WriteLine();
    ProdutoListar();
    Console.Write("Informe o n?? do produto que deseja excluir: ");
    int id = int.Parse(Console.ReadLine());
    // Instaciar a classe de Categoria
    Produto p = nproduto.Listar(id);
    // exclus??o da categoria
    nproduto.Excluir(p);
  }
  public static void PromocaoListar(){
    Console.WriteLine("|==== Lista de Promo????es ====|");
    Console.WriteLine();
  }
  public static void PromocaoInserir(){
    Console.WriteLine("|==== Inser????o de Promo????es ====|");
    Console.WriteLine();

  }
    public static void PromocaoAtualizar(){
    Console.WriteLine("|==== Atualiza????o de Promo????es ====|");
    Console.WriteLine();
  }
  public static void PromocaoExcluir(){
    Console.WriteLine("|==== Exclus??o de Promo????es ====|");
    Console.WriteLine();

  }
  public static void ClienteListar(){
    Console.WriteLine("|==== Lista de clientes ====|");
    // Lista os clientes
    Console.WriteLine();
    List<Cliente> cs = ncliente.Listar();
    if (cs.Count == 0){
      Console.WriteLine("Nenhum cliente cadastrado");
      return;
    }
    foreach (Cliente c in cs) Console.WriteLine(c);
    Console.WriteLine();

  }
  public static void ClienteInserir(){
    Console.WriteLine("|==== Inser????o de clientes ====|");
    Console.WriteLine();
    Console.Write("Informe o nome do cliente: ");
    string nome = Console.ReadLine();
    Console.Write("Informe a data de nascimento (dd/mm/aaaa): ");
    DateTime nasc = DateTime.Parse(Console.ReadLine());
    Console.Write("Informe seu telefone (00 00000-0000): ");
    string telefone = Console.ReadLine();
    Console.Write("Informe seu endere??o (rua, numero, bairro e cidade): ");
    string endere??o = Console.ReadLine();

    // Instaciar a classe de Cliente
    Cliente c = new Cliente { Nome = nome, Nascimento = nasc, Telefone = telefone, Endere??o = endere??o};
    // inser????o do cliente
    ncliente.Inserir(c);
  }
  public static void ClienteAtualizar(){
    Console.WriteLine("|==== Atualiza????o de clientes ====|");
    ClienteListar();
    Console.Write("Informe o c??digo do cliente que deseja atualizar: ");
    int id = int.Parse(Console.ReadLine());
    Console.Write("Informe o nome do cliente: ");
    string nome = Console.ReadLine();
    Console.Write("Informe a data de nascimento (dd/mm/aaaa): ");
    DateTime nasc = DateTime.Parse(Console.ReadLine());
    Console.Write("Informe seu telefone (00 00000-0000): ");
    string telefone = Console.ReadLine();
    Console.Write("Informe seu endere??o (rua, numero, bairro e cidade): ");
    string endere??o = Console.ReadLine();
    // Instaciar a classe de Cliente
    Cliente c = new Cliente { Id = id, Nome = nome, Nascimento = nasc, Telefone = telefone, Endere??o = endere??o};
    // Atualiza o cliente
    ncliente.Atualizar(c);

  }
  public static void ClienteExcluir(){
    Console.WriteLine("|==== Exclus??o de clientes ====|");
    ClienteListar();
    Console.Write("Informe o c??digo do cliente que deseja excluir: ");
    int id = int.Parse(Console.ReadLine());
    // Procura o cliente com esse id
    Cliente c = ncliente.Listar(id);
    // exclus??o do CLiente
    ncliente.Excluir(c);
  }
  public static void ClienteLogin(){
    Console.WriteLine("|----  Login do Cliente ----|");
    Console.WriteLine();
    ClienteListar();
    Console.Write("Informe o c??digo do cliente que deseja logar: ");
    int id = int.Parse(Console.ReadLine());
    // Logar o cliente com o id informado
    clienteLogin = ncliente.Listar(id);
  }
  public static void ClienteLogout(){
    Console.WriteLine("|----  Cliente Logout ----|");
    Console.WriteLine();
    clienteLogin = null;
  }
  public static void ClienteVendaListar(){
    Console.WriteLine("|----  Cliente Venda Listar ----|");
    Console.WriteLine();
  }
  public static void ClienteProdutoListar(){
    Console.WriteLine("|---- Cliente Produto Listar----|");
    Console.WriteLine();
  }
    public static void ClienteProdutoInserir(){
    Console.WriteLine("|---- Cliente Produto Inserir ----|");
    Console.WriteLine();
  }
  public static void ClienteCarrinhoVisualizar(){
    Console.WriteLine("|----  Cliente Carrinho Visualizar ----|");
    Console.WriteLine();
  }
  public static void ClienteCarrinhoLimpar(){
    Console.WriteLine("|----  Cliente Carrinho Limpar ----|");
    Console.WriteLine();
  }
  public static void ClienteCarrinhoComprar(){
    Console.WriteLine("|---- Cliente Carrinho Comprar----|");
    Console.WriteLine();
  }
}