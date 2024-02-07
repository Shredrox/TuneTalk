import { useEffect, useState } from "react";
import { useForm } from "react-hook-form";
import { z } from "zod";
import { zodResolver } from "@hookform/resolvers/zod";
import axios from "../../axios/axios";
import FormInput from "../FormInput";

const loginSchema = z.object({
  email: z.string().email().trim(),
  password: z.string().min(1, "Password is required")
})
  
type Inputs = z.infer<typeof loginSchema>

const Login = () => {
  const [error, setError] = useState('');

  const { 
    register,
    handleSubmit, 
    formState: { errors }, 
    watch 
  } = useForm<Inputs>({
    resolver: zodResolver(loginSchema)
  });

  const watchEmail = watch("email");
  const watchPassword = watch("password");

  useEffect(() =>{
    setError('');
  },[watchEmail, watchPassword])

  const onSubmit = async (data: Inputs) => {
    try {
      const response = await axios.post('auth/login',
        JSON.stringify(data),
        {
          headers: {'Content-Type': 'application/json'}
        }
      );
      console.log(response.data);
    } catch (error : any) {
      if(!error?.response){
        setError('No response');
      }else if(error.response?.status === 400){
        setError('An error occurred');
      }else if(error.response?.status === 401){
        setError('Incorrect email or password');
      }else{
        setError('Error');
      }
    }
  };

  return (
    <form
      onSubmit={handleSubmit(onSubmit)}
      noValidate
      className="flex flex-col justify-center items-center bg-gray-15 
      gap-3 p-4 white-98 w-1/2 rounded-2xl"
      >
      <h2 className="form-h2 white-98">Login</h2>

      <FormInput 
        type="email" 
        placeholder="Email" 
        register={register} 
        name="email" 
        error={errors.email?.message}
      />

      <FormInput 
        type="password" 
        placeholder="Password" 
        register={register} 
        name="password" 
        error={errors.password?.message}
      />
      
      <button className="form-button">Login</button>
      <p className="text-orange-600">{error}</p>
    </form>
  )
}

export default Login
