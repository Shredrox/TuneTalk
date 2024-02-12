import { useParams } from 'react-router-dom'

const Profile = () => {
  const {username} = useParams();

  return (
    <div className='text-white p-6 flex justify-center w-full'>
      Profile: {username} 
    </div>
  )
}

export default Profile
