using System.Collections.Generic;


namespace PartyInvites.Models {
    public static class BadmintonRepository
    {

        private static List<BadmintonResponse> responses = new List<BadmintonResponse>();

        public static IEnumerable<BadmintonResponse> Responses
        {
            get
            {
                return responses;
            }
        }
        public static void AddResponse(BadmintonResponse response)
        {
            responses.Add(response);
        }

    }
    
    
}
