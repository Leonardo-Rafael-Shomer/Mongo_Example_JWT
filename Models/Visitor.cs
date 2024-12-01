using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization;

namespace MongoExample.Models;



[BsonIgnoreExtraElements]
public class Visitor
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }
    
    [BsonElement("createdAt")]
    public DateTime CreatedAt { get; set; }

    [BsonElement("updatedAt")]
    public DateTime UpdatedAt { get; set; }

    [BsonElement("ativo")]
    public bool Ativo { get; set; }

    [BsonElement("userId")]
    [BsonRepresentation(BsonType.ObjectId)]
    public string UserId { get; set; }
    
    [BsonElement("search")]
    public string Search { get; set; }

    [BsonElement("nome")]
    public string Nome { get; set; }

    [BsonElement("documento")]
    public string? Documento { get; set; }

    [BsonElement("fone")]
    public string Fone { get; set; }

    [BsonElement("unidade")]
    public string Unidade { get; set; }

    [BsonElement("nomeEmpresa")]
    public string? NomeEmpresa { get; set; }

    [BsonElement("veiculoPlaca")]
    public string? VeiculoPlaca { get; set; }

    [BsonElement("veiculoCor")]
    public string? VeiculoCor { get; set; }

    [BsonElement("veiculoModelo")]
    public string? VeiculoModelo { get; set; }

    [BsonElement("veiculoMarca")]
    public string? VeiculoMarca { get; set; }

    [BsonElement("familia")]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Familia { get; set; }

    [BsonElement("condominio")]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Condominio { get; set; }

    [BsonElement("condominioCodigo")]
    public string CondominioCodigo { get; set; }

    [BsonElement("perfil")]
    public Perfil? Perfil { get; set; }

    [BsonElement("tipo")]
    public string Tipo { get; set; }

    [BsonElement("vinculo")]
    public string Vinculo { get; set; }

    [BsonElement("acesso")]
    public string Acesso { get; set; }

    [BsonElement("anunciar")]
    public bool Anunciar { get; set; }
    
}