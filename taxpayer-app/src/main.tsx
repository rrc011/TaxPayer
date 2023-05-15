import React from 'react'
import ReactDOM from 'react-dom/client'
import { BrowserRouter, Routes, Route, Navigate } from "react-router-dom";
import App from './App.tsx'
import './index.css'
import { HomePage } from './pages/home/HomePage.tsx';
import { TaxReceiptPage } from './pages/home/components/TaxReceiptPage.tsx';

ReactDOM.createRoot(document.getElementById('root') as HTMLElement).render(
  <React.StrictMode>
    <BrowserRouter>
      <Routes>
        <Route element={<App />}>
          <Route path="/" element={<HomePage />} />
          <Route path="/taxes/:id" element={<TaxReceiptPage />} />
          <Route path='*' element={<Navigate to='/' />} />
        </Route>
      </Routes>
    </BrowserRouter>
  </React.StrictMode>
)
