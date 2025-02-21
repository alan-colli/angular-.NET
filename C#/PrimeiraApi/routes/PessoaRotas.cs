using PrimeiraApi.models;

namespace PessoasRotas.Routes;

public static class PessoaRotas
{
    public static void MapPessoaRotas(this WebApplication app){
        app.MapGet("/api", () => new {Nome="Alan"});
        app.MapGet("/pessoas", ()=>Pessoas);
        app.MapGet("/pessoas/{nome}", (string nome)=> Pessoas.Find(x => x.Nome == nome));

        app.MapPost("/pessoas", (Pessoa pessoa)=>{
            Pessoas.Add(pessoa);
            return pessoa;});

        app.MapPut("/pessoas/{id}", (Guid id, Pessoa pessoa) => 
        {
            var encontrado = Pessoas.Find(x => x.Id == id);
            if (encontrado == null)
                return Results.NotFound();

            encontrado.Nome = pessoa.Nome;
            return Results.Ok(encontrado);
        } );


        
        
    }

    public static List<Pessoa> Pessoas = new(){
        new Pessoa(id: Guid.NewGuid(), nome:"Alan"),
        new Pessoa(id: Guid.NewGuid(), nome: "Aldo")
    };

    


}