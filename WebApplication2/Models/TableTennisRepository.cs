using System.Collections.Generic;


namespace PartyInvites.Models {
    public static class TableTennisRepository
    {
        private static List<TableTennisResponse> responses = new List<TableTennisResponse>();

        public static IEnumerable<TableTennisResponse> Responses
        {
            get
            {
                return responses;
            }
        }
        public static void AddResponse(TableTennisResponse response)
        {
            responses.Add(response);
        }

    }
    
    
}
