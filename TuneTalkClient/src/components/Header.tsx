import { useNavigate } from "react-router-dom";
import useLogout from "../hooks/useLogout";
import { ModeToggle } from "./ModeToggle";
import { Avatar, AvatarFallback, AvatarImage } from "./Avatar";
import {
  DropdownMenu,
  DropdownMenuContent,
  DropdownMenuItem,
  DropdownMenuLabel,
  DropdownMenuSeparator,
  DropdownMenuTrigger,
} from "@/components/DropdownMenu"
import {
  LogOut,
  User,
} from "lucide-react"

import SearchBar from "./SearchBar";

const Header = () => {
  const navigate = useNavigate();

  const logout = useLogout();

  const handleLogout = async () => {
    await logout();
    navigate('/');
  }

  return (
    <header className="bg-[#18191b] backdrop-blur 
    border-b supports-[backdrop-filter]:bg-background/60 
    w-full flex justify-between items-center h-16 p-4 fixed top-0 z-50">
      <h3 className="scroll-m-20 text-2xl font-semibold tracking-tight">TuneTalk</h3>
      <div className="w-1/3 flex relative">
        <SearchBar/>
      </div>
      <div className="w-1/3 flex items-center gap-4">
        <div className="w-12 h-12 bg-slate-500 flex justify-center items-center">yo</div>
        <div className="w-[600px] h-6 bg-slate-500 flex items-center">ayo</div>
      </div>
      <div className="flex gap-2">
        <ModeToggle/>
        <DropdownMenu>
          <DropdownMenuTrigger>
            <Avatar>
              <AvatarImage src="https://github.com/shadcn.png"/>
              <AvatarFallback>CN</AvatarFallback>
            </Avatar>
          </DropdownMenuTrigger>
          <DropdownMenuContent onCloseAutoFocus={(e) => e.preventDefault()}>
            <DropdownMenuLabel>My Account</DropdownMenuLabel>
            <DropdownMenuSeparator />
            <DropdownMenuItem onClick={() => navigate('/profile/hello')}>
              <User className="mr-2 h-4 w-4" />
              <span>Profile</span>
            </DropdownMenuItem>
            <DropdownMenuItem onClick={handleLogout}>
              <LogOut className="mr-2 h-4 w-4" />
              <span>Log out</span>
            </DropdownMenuItem>
          </DropdownMenuContent>
        </DropdownMenu>
      </div>
    </header>
  )
}

export default Header
