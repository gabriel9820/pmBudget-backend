using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace pmBudget.API.Responses
{
    public class pmBudgetInvalidModelStateResponse
    {
        public bool Success { get; private set; }
        public string Message { get; private set; }
        public IDictionary<string, string[]> Errors { get; private set; }

        public pmBudgetInvalidModelStateResponse(ActionContext actionContext)
        {
            Success = false;
            Message = "Erro de validação";
            Errors = new Dictionary<string, string[]>();

            AddErrorMessages(actionContext);
        }

        private void AddErrorMessages(ActionContext actionContext)
        {
            foreach (var propModelState in actionContext.ModelState)
            {
                var prop = propModelState.Key;
                var errorsList = propModelState.Value.Errors;

                if (errorsList != null && errorsList.Count > 0)
                {
                    if (errorsList.Count == 1)
                    {
                        var errorMessage = GetErrorMessage(errorsList[0]);
                        Errors.Add(prop, new[] { errorMessage });
                    }
                    else
                    {
                        var errorMessages = new string[errorsList.Count];

                        for (var i = 0; i < errorsList.Count; i++)
                        {
                            errorMessages[i] = GetErrorMessage(errorsList[i]);
                        }

                        Errors.Add(prop, errorMessages);
                    }
                }
            }
        }

        private string GetErrorMessage(ModelError modelError)
        {
            return string.IsNullOrEmpty(modelError.ErrorMessage) ? "O campo é inválido" : modelError.ErrorMessage;
        }
    }
}
