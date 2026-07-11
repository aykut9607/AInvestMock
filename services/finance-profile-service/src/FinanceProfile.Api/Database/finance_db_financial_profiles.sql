--
-- PostgreSQL database dump
--

\restrict TAX2fzjhSeEwcTyUaagDE3hJBDEj8QUNFQSA5YWh94fyjNeHeXW3OHukXyQ3OZW

-- Dumped from database version 17.10
-- Dumped by pg_dump version 17.10

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET transaction_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

SET default_tablespace = '';

SET default_table_access_method = heap;

--
-- Name: financial_profiles; Type: TABLE; Schema: public; Owner: -
--

CREATE TABLE public.financial_profiles (
    id uuid DEFAULT gen_random_uuid() NOT NULL,
    user_id character varying(100) NOT NULL,
    monthly_income numeric(18,2) NOT NULL,
    monthly_expenses numeric(18,2) NOT NULL,
    monthly_debt_payment numeric(18,2) NOT NULL,
    total_debt numeric(18,2) NOT NULL,
    cash_reserve numeric(18,2) NOT NULL,
    investment_amount numeric(18,2) NOT NULL,
    risk_preference character varying(20) NOT NULL,
    created_at timestamp with time zone DEFAULT now() NOT NULL,
    updated_at timestamp with time zone DEFAULT now() NOT NULL,
    CONSTRAINT financial_profiles_cash_reserve_check CHECK ((cash_reserve >= (0)::numeric)),
    CONSTRAINT financial_profiles_investment_amount_check CHECK ((investment_amount >= (0)::numeric)),
    CONSTRAINT financial_profiles_monthly_debt_payment_check CHECK ((monthly_debt_payment >= (0)::numeric)),
    CONSTRAINT financial_profiles_monthly_expenses_check CHECK ((monthly_expenses >= (0)::numeric)),
    CONSTRAINT financial_profiles_monthly_income_check CHECK ((monthly_income > (0)::numeric)),
    CONSTRAINT financial_profiles_risk_preference_check CHECK (((risk_preference)::text = ANY ((ARRAY['LOW'::character varying, 'MEDIUM'::character varying, 'HIGH'::character varying])::text[]))),
    CONSTRAINT financial_profiles_total_debt_check CHECK ((total_debt >= (0)::numeric))
);


--
-- Data for Name: financial_profiles; Type: TABLE DATA; Schema: public; Owner: -
--

INSERT INTO public.financial_profiles (id, user_id, monthly_income, monthly_expenses, monthly_debt_payment, total_debt, cash_reserve, investment_amount, risk_preference, created_at, updated_at) VALUES ('20e6bff1-1f7f-4a1a-abac-0b09a6681b30', 'demo-user-1', 70000.00, 20000.00, 5000.00, 20000.00, 50000.00, 20000.00, 'MEDIUM', '2026-07-10 03:44:14.033515+03', '2026-07-10 03:44:14.033515+03');
INSERT INTO public.financial_profiles (id, user_id, monthly_income, monthly_expenses, monthly_debt_payment, total_debt, cash_reserve, investment_amount, risk_preference, created_at, updated_at) VALUES ('de344a23-7ff6-45aa-af77-0af2b49f8ec8', 'demo-user-2', 45000.00, 30000.00, 8000.00, 120000.00, 10000.00, 5000.00, 'LOW', '2026-07-10 03:45:42.62106+03', '2026-07-10 03:45:42.62106+03');
INSERT INTO public.financial_profiles (id, user_id, monthly_income, monthly_expenses, monthly_debt_payment, total_debt, cash_reserve, investment_amount, risk_preference, created_at, updated_at) VALUES ('a4426ef1-8b7e-4936-9a9f-2ea7f431243a', 'demo-user-3', 90000.00, 35000.00, 4000.00, 30000.00, 120000.00, 25000.00, 'MEDIUM', '2026-07-10 03:45:42.62106+03', '2026-07-10 03:45:42.62106+03');
INSERT INTO public.financial_profiles (id, user_id, monthly_income, monthly_expenses, monthly_debt_payment, total_debt, cash_reserve, investment_amount, risk_preference, created_at, updated_at) VALUES ('b00df97b-b61f-4533-854b-480014691b94', 'demo-user-4', 30000.00, 25000.00, 7000.00, 90000.00, 3000.00, 10000.00, 'HIGH', '2026-07-10 03:45:42.62106+03', '2026-07-10 03:45:42.62106+03');
INSERT INTO public.financial_profiles (id, user_id, monthly_income, monthly_expenses, monthly_debt_payment, total_debt, cash_reserve, investment_amount, risk_preference, created_at, updated_at) VALUES ('bb7623a0-4315-421b-b9e2-c2bb9751a4ea', 'demo-user-5', 120000.00, 40000.00, 10000.00, 60000.00, 200000.00, 40000.00, 'HIGH', '2026-07-10 03:45:42.62106+03', '2026-07-10 03:45:42.62106+03');
INSERT INTO public.financial_profiles (id, user_id, monthly_income, monthly_expenses, monthly_debt_payment, total_debt, cash_reserve, investment_amount, risk_preference, created_at, updated_at) VALUES ('4dafab2d-78c3-4b5d-b3ae-014c1796f914', 'demo-user-6', 60000.00, 28000.00, 6000.00, 45000.00, 35000.00, 12000.00, 'MEDIUM', '2026-07-10 03:45:42.62106+03', '2026-07-10 03:45:42.62106+03');


--
-- Name: financial_profiles financial_profiles_pkey; Type: CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.financial_profiles
    ADD CONSTRAINT financial_profiles_pkey PRIMARY KEY (id);


--
-- Name: financial_profiles financial_profiles_user_id_key; Type: CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.financial_profiles
    ADD CONSTRAINT financial_profiles_user_id_key UNIQUE (user_id);


--
-- PostgreSQL database dump complete
--

\unrestrict TAX2fzjhSeEwcTyUaagDE3hJBDEj8QUNFQSA5YWh94fyjNeHeXW3OHukXyQ3OZW

