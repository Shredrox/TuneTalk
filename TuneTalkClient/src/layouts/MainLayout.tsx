import { Outlet } from 'react-router-dom'
import Header from '../components/Header'
import Sidebar from '../components/Sidebar'

const MainLayout = () => {
  return (
    <>
      <Header/>
      <main className='flex h-[200vh]'>
        <Sidebar/>
        <Outlet />
      </main>
    </>
  )
}

export default MainLayout
