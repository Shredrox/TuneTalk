import { Route, createBrowserRouter, createRoutesFromElements } from "react-router-dom";
import Landing from "../pages/Landing";
import MainLayout from "../layouts/MainLayout";
import Home from "../pages/Home";
import ProtectedRoute from "../routes/ProtectedRoute";

export const MainRouter = createBrowserRouter(
  createRoutesFromElements(
    <Route>
      <Route path="/" element={<Landing/>}/>
      <Route element={<MainLayout/>}>
        <Route element={<ProtectedRoute/>}>
          <Route path="/home" element={<Home/>}/>
        </Route>
      </Route>
    </Route>
  )
);
