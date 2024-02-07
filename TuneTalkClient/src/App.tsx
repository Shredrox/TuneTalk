import { RouterProvider } from "react-router-dom";
import { MainRouter } from "./router/MainRouter";

function App() {
  return (
    <div>
      <RouterProvider router={MainRouter}/>
    </div>
  )
}

export default App
