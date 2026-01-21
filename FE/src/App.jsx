import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';
import './index.css'

function Home() {
  return (
    <div className="flex h-screen items-center justify-center bg-gray-100">
      <h1 className="text-4xl font-bold text-blue-600">MiniYoutube FE</h1>
    </div>
  );
}

function App() {
  return (
    <Router>
      <Routes>
        <Route path="/" element={<Home />} />
      </Routes>
    </Router>
  );
}

export default App;
