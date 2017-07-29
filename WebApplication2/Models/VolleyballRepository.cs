using System.Collections.Generic;


namespace PartyInvites.Models {
    public static class VolleyballRepository
    {
        private static List<VolleyBallResponse> responses = new List<VolleyBallResponse>();

        public static IEnumerable<VolleyBallResponse> Responses
        {
            get
            {
                return responses;
            }
        }
        public static void AddResponse(VolleyBallResponse response)
        {
            responses.Add(response);
        }

    }
    
    
}
