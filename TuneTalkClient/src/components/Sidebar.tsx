import { Link, useLocation } from 'react-router-dom'
import { IoHome } from "react-icons/io5";
import { IoChatbubbles } from "react-icons/io5";

const Sidebar = () => {
  const location = useLocation();
  
  const isActive = (path : string) =>{
    return location.pathname.includes(path) ? 
    'bg-black' : 
    ''
  }

  const linksData = [
    { id: 1, to: '/home', text: 'Home', icon: <IoHome/> },
    { id: 2, to: '/chats', text: 'Chats', icon: <IoChatbubbles/> }
  ];

  return (
    <div className="text-white bg-[#0f1012] h-screen sticky top-12 p-4 w-[140px]">
      <ul className='flex flex-col gap-2'>
        {linksData.map((link) =>
          <li key={link.id}>
            <Link key={link.id} to={link.to}>
              <button 
                key={link.id} 
                className={`flex items-center text-xl p-2 rounded gap-2
                ${isActive(link.to)}`}
                >
                {link.icon}
                {link.text}
              </button>
            </Link>
          </li>
        )}
      </ul>
    </div>
  )
}

export default Sidebar
