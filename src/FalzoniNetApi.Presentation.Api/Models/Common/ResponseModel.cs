using System.Net;

namespace FalzoniNetApi.Presentation.Api.Models.Common
{
    public class ResponseModel
    {
        public HttpStatusCode StatusCode { get; set; }
        public string? Message { get; set; }

        #region Builder Methods
        public ResponseModel SetSuccess(string message)
        {
            StatusCode = HttpStatusCode.OK;
            Message = message;
            return this;
        }

        public ResponseModel SetCreated(string message)
        {
            StatusCode = HttpStatusCode.Created;
            Message = message;
            return this;
        }

        public ResponseModel SetBadRequest(string message)
        {
            StatusCode = HttpStatusCode.BadRequest;
            Message = message;
            return this;
        }

        public ResponseModel SetNotFound()
        {
            StatusCode = HttpStatusCode.NotFound;
            Message = "Método ou recurso não encontrado!";
            return this;
        }

        public ResponseModel SetForbidden()
        {
            StatusCode = HttpStatusCode.Forbidden;
            Message = "Você não possui permissão para ver este conteúdo";
            return this;
        }

        public ResponseModel SetUnauthorized()
        {
            StatusCode = HttpStatusCode.Unauthorized;
            Message = "Você não está autorizado a ver este conteúdo";
            return this;
        }

        public ResponseModel SetInternalServerError(string message)
        {
            StatusCode = HttpStatusCode.InternalServerError;
            Message = message;
            return this;
        }
        #endregion
    }
}
