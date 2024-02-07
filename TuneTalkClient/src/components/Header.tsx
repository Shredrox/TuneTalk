import { useNavigate } from "react-router-dom";
import useLogout from "../hooks/useLogout";

const Header = () => {
  const navigate = useNavigate();

  const logout = useLogout();

  const handleLogout = async () => {
    await logout();
    navigate('/');
  }

  return (
    <div className="bg-[#18191b] text-white w-full flex justify-between items-center h-12 p-4 sticky top-0">
      TuneTalk
      <button onClick={handleLogout}>Logout</button>
    </div>
  )
}

export default Header
