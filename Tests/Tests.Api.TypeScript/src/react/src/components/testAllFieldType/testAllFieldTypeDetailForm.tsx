import React, { Component } from 'react';
import axios from 'axios';
import * as Api from '../../api/models';
import { UpdateResponse } from '../../api/ApiObjects'
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import { FormikProps,FormikErrors, Field, withFormik } from 'formik';
import { LoadingForm } from '../../lib/components/loadingForm'
import { ErrorForm } from '../../lib/components/errorForm'
import TestAllFieldTypeMapper from './testAllFieldTypeMapper';
import TestAllFieldTypeViewModel from './testAllFieldTypeViewModel';

interface Props {
	history:any;
    model?:TestAllFieldTypeViewModel
}

const TestAllFieldTypeDetailDisplay = (model:Props) => {

   return (
          <form  role="form">
				<button
                  className="btn btn-primary btn-sm align-middle float-right vertically-center"
                  onClick={(e) => { model.history.push(ClientRoutes.TestAllFieldTypes + '/edit/' + model.model!.id)}}
                >
                  <i className="fas fa-edit" />
                </button>
			 						 <div className="form-group row">
							<label htmlFor="fieldBigInt" className={"col-sm-2 col-form-label"}>FieldBigInt</label>
							<div className="col-sm-12">
								{String(model.model!.fieldBigInt)}
							</div>
						</div>
					   						 <div className="form-group row">
							<label htmlFor="fieldBinary" className={"col-sm-2 col-form-label"}>FieldBinary</label>
							<div className="col-sm-12">
								{String(model.model!.fieldBinary)}
							</div>
						</div>
					   						 <div className="form-group row">
							<label htmlFor="fieldBit" className={"col-sm-2 col-form-label"}>FieldBit</label>
							<div className="col-sm-12">
								{String(model.model!.fieldBit)}
							</div>
						</div>
					   						 <div className="form-group row">
							<label htmlFor="fieldChar" className={"col-sm-2 col-form-label"}>FieldChar</label>
							<div className="col-sm-12">
								{String(model.model!.fieldChar)}
							</div>
						</div>
					   						 <div className="form-group row">
							<label htmlFor="fieldDate" className={"col-sm-2 col-form-label"}>FieldDate</label>
							<div className="col-sm-12">
								{String(model.model!.fieldDate)}
							</div>
						</div>
					   						 <div className="form-group row">
							<label htmlFor="fieldDateTime" className={"col-sm-2 col-form-label"}>FieldDateTime</label>
							<div className="col-sm-12">
								{String(model.model!.fieldDateTime)}
							</div>
						</div>
					   						 <div className="form-group row">
							<label htmlFor="fieldDateTime2" className={"col-sm-2 col-form-label"}>FieldDateTime2</label>
							<div className="col-sm-12">
								{String(model.model!.fieldDateTime2)}
							</div>
						</div>
					   						 <div className="form-group row">
							<label htmlFor="fieldDateTimeOffset" className={"col-sm-2 col-form-label"}>FieldDateTimeOffset</label>
							<div className="col-sm-12">
								{String(model.model!.fieldDateTimeOffset)}
							</div>
						</div>
					   						 <div className="form-group row">
							<label htmlFor="fieldDecimal" className={"col-sm-2 col-form-label"}>FieldDecimal</label>
							<div className="col-sm-12">
								{String(model.model!.fieldDecimal)}
							</div>
						</div>
					   						 <div className="form-group row">
							<label htmlFor="fieldFloat" className={"col-sm-2 col-form-label"}>FieldFloat</label>
							<div className="col-sm-12">
								{String(model.model!.fieldFloat)}
							</div>
						</div>
					   						 <div className="form-group row">
							<label htmlFor="fieldImage" className={"col-sm-2 col-form-label"}>FieldImage</label>
							<div className="col-sm-12">
								{String(model.model!.fieldImage)}
							</div>
						</div>
					   						 <div className="form-group row">
							<label htmlFor="fieldMoney" className={"col-sm-2 col-form-label"}>FieldMoney</label>
							<div className="col-sm-12">
								{String(model.model!.fieldMoney)}
							</div>
						</div>
					   						 <div className="form-group row">
							<label htmlFor="fieldNChar" className={"col-sm-2 col-form-label"}>FieldNChar</label>
							<div className="col-sm-12">
								{String(model.model!.fieldNChar)}
							</div>
						</div>
					   						 <div className="form-group row">
							<label htmlFor="fieldNText" className={"col-sm-2 col-form-label"}>FieldNText</label>
							<div className="col-sm-12">
								{String(model.model!.fieldNText)}
							</div>
						</div>
					   						 <div className="form-group row">
							<label htmlFor="fieldNumeric" className={"col-sm-2 col-form-label"}>FieldNumeric</label>
							<div className="col-sm-12">
								{String(model.model!.fieldNumeric)}
							</div>
						</div>
					   						 <div className="form-group row">
							<label htmlFor="fieldNVarchar" className={"col-sm-2 col-form-label"}>FieldNVarchar</label>
							<div className="col-sm-12">
								{String(model.model!.fieldNVarchar)}
							</div>
						</div>
					   						 <div className="form-group row">
							<label htmlFor="fieldReal" className={"col-sm-2 col-form-label"}>FieldReal</label>
							<div className="col-sm-12">
								{String(model.model!.fieldReal)}
							</div>
						</div>
					   						 <div className="form-group row">
							<label htmlFor="fieldSmallDateTime" className={"col-sm-2 col-form-label"}>FieldSmallDateTime</label>
							<div className="col-sm-12">
								{String(model.model!.fieldSmallDateTime)}
							</div>
						</div>
					   						 <div className="form-group row">
							<label htmlFor="fieldSmallInt" className={"col-sm-2 col-form-label"}>FieldSmallInt</label>
							<div className="col-sm-12">
								{String(model.model!.fieldSmallInt)}
							</div>
						</div>
					   						 <div className="form-group row">
							<label htmlFor="fieldSmallMoney" className={"col-sm-2 col-form-label"}>FieldSmallMoney</label>
							<div className="col-sm-12">
								{String(model.model!.fieldSmallMoney)}
							</div>
						</div>
					   						 <div className="form-group row">
							<label htmlFor="fieldText" className={"col-sm-2 col-form-label"}>FieldText</label>
							<div className="col-sm-12">
								{String(model.model!.fieldText)}
							</div>
						</div>
					   						 <div className="form-group row">
							<label htmlFor="fieldTime" className={"col-sm-2 col-form-label"}>FieldTime</label>
							<div className="col-sm-12">
								{String(model.model!.fieldTime)}
							</div>
						</div>
					   						 <div className="form-group row">
							<label htmlFor="fieldTimestamp" className={"col-sm-2 col-form-label"}>FieldTimestamp</label>
							<div className="col-sm-12">
								{String(model.model!.fieldTimestamp)}
							</div>
						</div>
					   						 <div className="form-group row">
							<label htmlFor="fieldTinyInt" className={"col-sm-2 col-form-label"}>FieldTinyInt</label>
							<div className="col-sm-12">
								{String(model.model!.fieldTinyInt)}
							</div>
						</div>
					   						 <div className="form-group row">
							<label htmlFor="fieldUniqueIdentifier" className={"col-sm-2 col-form-label"}>FieldUniqueIdentifier</label>
							<div className="col-sm-12">
								{String(model.model!.fieldUniqueIdentifier)}
							</div>
						</div>
					   						 <div className="form-group row">
							<label htmlFor="fieldVarBinary" className={"col-sm-2 col-form-label"}>FieldVarBinary</label>
							<div className="col-sm-12">
								{String(model.model!.fieldVarBinary)}
							</div>
						</div>
					   						 <div className="form-group row">
							<label htmlFor="fieldVarchar" className={"col-sm-2 col-form-label"}>FieldVarchar</label>
							<div className="col-sm-12">
								{String(model.model!.fieldVarchar)}
							</div>
						</div>
					   						 <div className="form-group row">
							<label htmlFor="fieldXML" className={"col-sm-2 col-form-label"}>FieldXML</label>
							<div className="col-sm-12">
								{String(model.model!.fieldXML)}
							</div>
						</div>
					   						 <div className="form-group row">
							<label htmlFor="id" className={"col-sm-2 col-form-label"}>Id</label>
							<div className="col-sm-12">
								{String(model.model!.id)}
							</div>
						</div>
					             </form>
  );
}

  interface IParams 
  {
     id:number;
  }
  
  interface IMatch
  {
     params: IParams;
  }

  interface TestAllFieldTypeDetailComponentProps
  {
     match:IMatch;
	 history:any;
  }

  interface TestAllFieldTypeDetailComponentState
  {
      model?:TestAllFieldTypeViewModel;
      loading:boolean;
      loaded:boolean;
      errorOccurred:boolean;
      errorMessage:string;
  }


  export default class TestAllFieldTypeDetailComponent extends React.Component<TestAllFieldTypeDetailComponentProps, TestAllFieldTypeDetailComponentState> {

    state = ({model:undefined, loading:false, loaded:false, errorOccurred:false, errorMessage:''});

    componentDidMount () {
        this.setState({...this.state,loading:true});

        axios.get(Constants.ApiEndpoint + ApiRoutes.TestAllFieldTypes + '/' + this.props.match.params.id,
        {
            headers: {
                'Content-Type': 'application/json',
            }
        })
        .then(resp => {
            let response = resp.data as Api.TestAllFieldTypeClientResponseModel;
            
			let mapper = new TestAllFieldTypeMapper();

            console.log(response);

            this.setState({model:mapper.mapApiResponseToViewModel(response), loading:false, loaded:true, errorOccurred:false, errorMessage:''});

        }, error => {
            console.log(error);
            this.setState({model:undefined, loading:false, loaded:false, errorOccurred:true, errorMessage:'Error from API'});
        })
    }
    render () {

        if (this.state.loading) {
            return <LoadingForm />;
        } 
		else if (this.state.errorOccurred) {
            return <ErrorForm message={this.state.errorMessage} />;
        }
        else if (this.state.loaded) {
            return (<TestAllFieldTypeDetailDisplay history={this.props.history} model={this.state.model} />);
        } 
		else {
		  return null;
		}
    }
}

/*<Codenesium>
    <Hash>33d493a899ab7ed195e9b1d2cadc61d1</Hash>
</Codenesium>*/