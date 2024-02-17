import { useQuery } from "@tanstack/react-query"
import { getSpotifyProfile } from "../../services/spotifyService";

const useSpotifyProfileData = () =>{
  const { 
    data: spotifyProfile, 
    isLoading: isSpotifyProfileLoading, 
    isError: isSpotifyProfileError,
    error: spotifyProfileError 
  } = useQuery({
    queryKey: ['spotify'],
    queryFn: getSpotifyProfile
  });

  return {
    spotifyProfile, 
    isSpotifyProfileLoading, 
    isSpotifyProfileError, 
    spotifyProfileError
  }
}

export default useSpotifyProfileData
