import axios from "../axios/axios";
import SpotifyProfile from "../interfaces/spotify/SpotifyProfile";

export const getSpotifyProfile = async () : Promise<SpotifyProfile> =>{
  const response = await axios.get('/Spotify/profile');
  return response.data;
}
