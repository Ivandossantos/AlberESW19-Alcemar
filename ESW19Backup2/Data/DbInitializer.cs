using ESW19Backup2.Models;
using ESW19Backup2.Models.Apoios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ESW19Backup2.Data
{
    public class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();
            if (!context.Ajudas.Any())
            {
                context.Ajudas.Add(new Ajuda("Account", "Login", "Email", "Email associado à conta."));
                context.Ajudas.Add(new Ajuda("Account", "Login", "Password", "Password associada à conta."));
                context.Ajudas.Add(new Ajuda("Account", "Login", "RememberMe", "Seleccione esta opção caso pretende que o login fique feito mesmo após fechar o navegador."));

                context.Ajudas.Add(new Ajuda("Account", "Registo", "Email",
                   "Preencha com um email válido." +
                   "<br /> " +
                   "<strong>Nota:</strong> Terá que ativá-lo antes de poder aceder à sua conta."));
                context.Ajudas.Add(new Ajuda("Account", "Registo", "Password",
                   "Preencha com a password que pretende." +
                   "<br />" +
                   "<strong>Nota:</strong> " +
                   "<br /><ul>" +
                   "<li>Tem que ter pelo menos 6 caracteres.</li>" +
                   "<li>Tem que ter pelo menos um número.</li>" +
                   "<li>Tem que ter pelo menos uma maiúscula</li>" +
                   "<li>Tem que ter pelo menos um caracter especial.</li>" +
                   "</ul>"));

                context.Ajudas.Add(new Ajuda("Account", "Registo", "ConfirmarPassword", "Repita a password que introduziu acima."));

                context.Ajudas.Add(new Ajuda("Account", "ForgotPassword", "Email", "Preencha com o email pertencente à conta cuja password pretende recuperar."));

                context.Ajudas.Add(new Ajuda("Account", "ResetPassword", "Password",
                    "Preencha com a nova password." +
                    "<br />" +
                    "<strong>Nota:</strong> " +
                    "<br /><ul>" +
                    "<li>Tem que ter pelo menos 6 caracteres.</li>" +
                    "<li>Tem que ter pelo menos um número.</li>" +
                    "<li>Tem que ter pelo menos uma maiúscula</li>" +
                    "<li>Tem que ter pelo menos um caracter especial.</li>" +
                    "</ul>"));
                context.Ajudas.Add(new Ajuda("Account", "ResetPassword", "ConfirmarPassword", "Repita a nova password."));

                context.Ajudas.Add(new Ajuda("Manage", "ChangePassword", "PasswordAntiga", "Para alterar a sua password, tem que introduzir neste campo a sua password atual."));
                context.Ajudas.Add(new Ajuda("Manage", "ChangePassword", "NovaPassword",
                    "Preencha com a password para a qual deseja alterar." +
                    "<br />" +
                    "<strong>Nota:</strong> " +
                    "<br /><ul>" +
                    "<li>Tem que ter pelo menos 6 caracteres.</li>" +
                    "<li>Tem que ter pelo menos um número.</li>" +
                    "<li>Tem que ter pelo menos uma maiúscula</li>" +
                    "<li>Tem que ter pelo menos um caracter especial.</li>" +
                    "</ul>"));
                context.Ajudas.Add(new Ajuda("Manage", "ChangePassword", "ConfirmarNovaPassword", "Confirme a password que introduziu no campo acima."));

                context.Ajudas.Add(new Ajuda("Account", "Login", "ModalAjuda",
                   "<p>Esta página permite-lhe introduzir os seus dados e aceder ao sistema. Para tal precisa de estar registado.</p><br />" +
                   "<strong><p>Observações:</p></strong>  " +
                   "<ul><li>Caso não possua uma conta, pode criá-la clicando em registar;</li>" +
                   "<li>Caso possua uma conta mas não se lembre da sua password, pode sempre recuperá-la através da opção de recuperação da mesma;" +
                   "<li>Caso se tenha acabado de registar mas não estiver a conseguir aceder, lembre-se que tem que a ativar no email que nos forneceu;</li></ul>"
                   ));

                context.Ajudas.Add(new Ajuda("Account", "Register", "ModalAjuda",
                   "<p>Esta página permite-lhe criar uma conta de acesso ao sistema.</p>" +
                   "<p>Para tal basta preencher o formulário corretamente com a sua informação e submeter o mesmo.</p>" +
                   "<p><strong>Nota:</strong> Depois da submissão do formulário terá que ativar a conta no email que nos forneceu, clicando no link fornecido para o efeito.</p>"
                   ));

               

                context.Ajudas.Add(new Ajuda("Caos", "Index", "ModalAjuda",
                    "<p>Esta página permite-lhe ver todos os cães que estão disponiveis para adoção.</p>" +
                    "<p>Clica-se num dos cães, e ve as informações todas so cão, e carregando no ´Mais Info´, consegue se ver as informações sobre o estado das vacinas " +
                    "<p>Ainda tem os butões para adotar, ou apadrinhar um dos nossos cães<p>"
                 ));

                context.Ajudas.Add(new Ajuda("Evento", "Index", "ModalAjuda",
                    "<p>Esta pagina permite-lhe ver todas os eventos que o AlberCool irá fazer<p>" +
                    "<p>Tendo a possibilidade de poder-se inscreve nos eventos, cujo uns são gratis, e outros têm um custo significativo <p>"
                    ));


                context.SaveChanges();

            }

            if (!context.Erros.Any())
            {
                context.Erros.Add(new Erro("001", "Credenciais Inválidas."));
                context.Erros.Add(new Erro("002", "Login falhou. Verifique se preencheu todos os campos!"));
                context.Erros.Add(new Erro("003", "Verifique se os dados introduzidos estão corretos."));
                context.Erros.Add(new Erro("004", "Registo falhou. Já existe uma conta com esse username."));
                context.Erros.Add(new Erro("005", "Ocorreu um erro inesperado! Tente novamente mais tarde."));
                context.SaveChanges();
            }

            if (!context.Horarios.Any())
            {

                context.Horarios.Add(new Horarios { Hora = "Das 08:00 as 16:00", Data = DayOfWeek.Monday });
                context.Horarios.Add(new Horarios { Hora = "Das 10:00 as 18:00", Data = DayOfWeek.Tuesday });
                context.Horarios.Add(new Horarios { Hora = "Das 12:00 as 20:00", Data = DayOfWeek.Wednesday });
                context.Horarios.Add(new Horarios { Hora = "Das 14:00 as 22:00", Data = DayOfWeek.Thursday });
                context.Horarios.Add(new Horarios { Hora = "Das 16:00 as 24:00", Data = DayOfWeek.Friday });
                context.Horarios.Add(new Horarios { Hora = "Das 18:00 as 02:00", Data = DayOfWeek.Saturday });

                context.SaveChanges();
            }
            if (!context.Tarefa.Any()) { 


                context.Tarefa.Add(new Tarefa { Nome = "Dar Banho", Descricao = "Esta Tarefa consiste em bar banho aos cães" });
                context.Tarefa.Add(new Tarefa { Nome = "Brincar", Descricao = "Consiste em brincar com os cães" });
                context.Tarefa.Add(new Tarefa { Nome = "Dar Comida", Descricao = "Esta Tarefa consiste em alimentar os cães" });
                context.Tarefa.Add(new Tarefa { Nome = "Limpar as casas", Descricao = "Esta Tarefa consiste em limpar as casas que se encontram os cães" });
                context.Tarefa.Add(new Tarefa { Nome = "Cuidados higienicos", Descricao = "Esta Tarefa consiste limpar os cães, incluindo cortar a unha, limpar os ouvidos" });
                context.Tarefa.Add(new Tarefa { Nome = "Preparar para as injecções", Descricao = "Esta Tarefa consiste em levar os cães para a sala de injecções, e prepara-los" });
                context.Tarefa.Add(new Tarefa { Nome = "Dar Banho", Descricao = "Esta Tarefa consiste em bar banho aos cães" });
                
                context.SaveChanges();
            }

            if (!context.Funcionarios.Any())
            {
                context.Funcionarios.Add(new Funcionario { Nome = "Alcemar", Sobrenome = "Costa" });
                context.Funcionarios.Add(new Funcionario { Nome = "Renata", Sobrenome = "Figueiredo" });
                context.Funcionarios.Add(new Funcionario { Nome = "Ivan", Sobrenome = "Dos Santos" });
                context.Funcionarios.Add(new Funcionario { Nome = "Izilda", Sobrenome = "Kossi" });
                context.Funcionarios.Add(new Funcionario { Nome = "Paulo", Sobrenome = "Fournier" });
                context.Funcionarios.Add(new Funcionario { Nome = "Nuno", Sobrenome = "Pina" });
                context.Funcionarios.Add(new Funcionario { Nome = "Cristiano", Sobrenome = "Ronaldo" });
                context.Funcionarios.Add(new Funcionario { Nome = "Messi", Sobrenome = "Lionel" });

            }

            if (!context.Estados.Any())
            {
                context.Estados.Add(new Estado() { Nome = "Vacinado" });
                context.Estados.Add(new Estado() { Nome = "Em Espera" });
                context.Estados.Add(new Estado() { Nome = "Cancelado" });
                //context.Estados.Add(new Estado() { Nome = "Sendo Feito" });
               
                context.SaveChanges();
            }

            if (!context.Cao.Any())
            {
                context.Cao.Add(new Cao() { Nome = "Princesa", Idade = 1.3, Raca = "PEMBROKE WELSH CORGI" });
                context.Cao.Add(new Cao() { Nome = "Mel", Idade = 0.9, Raca = "BICHON MALTÊS" });
                context.Cao.Add(new Cao() { Nome = "Win", Idade = 4.2, Raca = "LABRADOR RETRIEVER" });
                context.Cao.Add(new Cao() { Nome = "Rex", Idade = 0, Raca = "" });
                context.Cao.Add(new Cao() { Nome = "Key", Idade = 0, Raca = "" });
                context.Cao.Add(new Cao() { Nome = "Flexa", Idade = 0, Raca = "" });
                context.Cao.Add(new Cao() { Nome = "Zeus", Idade = 0, Raca = "" });
                context.Cao.Add(new Cao() { Nome = "Dozela", Idade = 0, Raca = "" });
                context.Cao.Add(new Cao() { Nome = "Layca", Idade = 0, Raca = "" });
                context.Cao.Add(new Cao() { Nome = "Simba", Idade = 0, Raca = "" });
                context.Cao.Add(new Cao() { Nome = "Xanana", Idade = 0, Raca = "" });
              

                context.SaveChanges();
            }
            if (!context.Areas.Any())
            {
                context.Areas.Add(new Models.Apoios.Area() { Nomes = "Educação" });
                context.Areas.Add(new Models.Apoios.Area() { Nomes = "Apoio directo ao Animal" });
                context.Areas.Add(new Models.Apoios.Area() { Nomes = "Web Designer" });

                context.SaveChanges();


            }

            if (!context.TipoApadrinhamento.Any())
            {
                context.TipoApadrinhamento.Add(new TipoApadrinhamento() { Tipo = "Apoio Monetário" });
                context.TipoApadrinhamento.Add(new TipoApadrinhamento() { Tipo = "Alimentação" });
                context.TipoApadrinhamento.Add(new TipoApadrinhamento() { Tipo = "Medicação/Cuidados Medicos" });
                context.TipoApadrinhamento.Add(new TipoApadrinhamento() { Tipo = "Outros" });

                context.SaveChanges();

            }

            if (!context.TipoPrioridades.Any())
            {
                context.TipoPrioridades.Add(new TipoPrioridade() { tipos = "Alta" });
                context.TipoPrioridades.Add(new TipoPrioridade() { tipos = "Media" });
                context.TipoPrioridades.Add(new TipoPrioridade() { tipos = "Baixa" });

                context.SaveChanges();

            }

        }
        }
    }
