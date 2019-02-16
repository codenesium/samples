import React, { Component } from 'react';
import axios from 'axios';
import * as Api from '../../api/models';
import { UpdateResponse } from '../../api/ApiObjects'
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import { FormikProps,FormikErrors, Field, withFormik } from 'formik';
import { LoadingForm } from '../../lib/components/loadingForm'
import { ErrorForm } from '../../lib/components/errorForm'
import ClaspViewModel from './claspViewModel';
import ClaspMapper from './claspMapper';

interface Props {
    model?:ClaspViewModel
}

  const ClaspEditDisplay = (props: FormikProps<ClaspViewModel>) => {

   let status = props.status as UpdateResponse<Api.ClaspClientRequestModel>;
   
   let errorsForField = (name:string) : string =>
   { 
        let response = '';
        if(props.touched[name as keyof ClaspViewModel]  && props.errors[name as keyof ClaspViewModel]) {
            response += props.errors[name as keyof ClaspViewModel];
        }

        if(status && status.validationErrors && status.validationErrors.find(f => f.propertyName.toLowerCase() == name.toLowerCase())) {
            response += status.validationErrors.filter(f => f.propertyName.toLowerCase() == name.toLowerCase())[0].errorMessage;
        }

        return response;
   }

    
   let errorExistForField = (name:string) : boolean =>
   {
        return errorsForField(name) != '';
   }

   return (

          <form onSubmit={props.handleSubmit} role="form">
							<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("id") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>Id</label>
					    <div className="col-sm-12">
                             <Field type="textbox" name="id" className={errorExistForField("id") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("id") && <small className="text-danger">{errorsForField("id")}</small>}
                        </div>
                    </div>
							<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("nextChainId") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>NextChainId</label>
					    <div className="col-sm-12">
                             <Field type="textbox" name="nextChainId" className={errorExistForField("nextChainId") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("nextChainId") && <small className="text-danger">{errorsForField("nextChainId")}</small>}
                        </div>
                    </div>
							<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("previousChainId") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>PreviousChainId</label>
					    <div className="col-sm-12">
                             <Field type="textbox" name="previousChainId" className={errorExistForField("previousChainId") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("previousChainId") && <small className="text-danger">{errorsForField("previousChainId")}</small>}
                        </div>
                    </div>
			
            <button type="submit" className="btn btn-primary" disabled={false}>
                Submit
            </button>
            <br />
            <br />
            { 
                status && status.success ? (<div className="alert alert-success">Success</div>): (null)
            }
                        
            { 
                status && !status.success ? (<div className="alert alert-danger">Error occurred</div>): (null)
            }
          </form>
  );
}


const ClaspEdit = withFormik<Props, ClaspViewModel>({
    mapPropsToValues: props => {
        let response = new ClaspViewModel();
		response.setProperties(props.model!.id,props.model!.nextChainId,props.model!.previousChainId);	
		return response;
      },
  
    // Custom sync validation
    validate: values => {
      let errors:FormikErrors<ClaspViewModel> = { };

	  if(values.id == 0) {
                errors.id = "Required"
                    }if(values.nextChainId == 0) {
                errors.nextChainId = "Required"
                    }if(values.previousChainId == 0) {
                errors.previousChainId = "Required"
                    }

      return errors;
    },
    handleSubmit: (values, actions) => {
        actions.setStatus(undefined);
		  
	    let mapper = new ClaspMapper();

        axios.put(Constants.ApiEndpoint + ApiRoutes.Clasps +'/' + values.id,
           
	    mapper.mapViewModelToApiRequest(values),
        {
            headers: {
                'Content-Type': 'application/json',
            }
        })
        .then(resp => {
            let response = resp.data as UpdateResponse<Api.ClaspClientRequestModel>;
            actions.setStatus(response);
            console.log(response);
        }, 
		error => {
		    console.log(error);
            actions.setStatus('Error from API');
        })
        .then(response =>
        {
            // cleanup
        })
    },
  
    displayName: 'ClaspEdit', 
  })(ClaspEditDisplay);

 
  interface IParams 
  {
     id:number;
  }

  interface IMatch
  {
     params: IParams;
  }
  
  interface ClaspEditComponentProps
  {
     match:IMatch;
  }

  interface ClaspEditComponentState
  {
      model?:ClaspViewModel;
      loading:boolean;
      loaded:boolean;
      errorOccurred:boolean;
      errorMessage:string;
  }

  export default class ClaspEditComponent extends React.Component<ClaspEditComponentProps, ClaspEditComponentState> {

    state = ({model:undefined, loading:false, loaded:false, errorOccurred:false, errorMessage:''});

    componentDidMount () {
        this.setState({...this.state,loading:true});

        axios.get(Constants.ApiEndpoint + ApiRoutes.Clasps + '/' + this.props.match.params.id, {
            headers: {
                'Content-Type': 'application/json',
            }
        })
        .then(resp => {
            let response = resp.data as Api.ClaspClientResponseModel;
            
            console.log(response);

			let mapper = new ClaspMapper();

            this.setState({model:mapper.mapApiResponseToViewModel(response), loading:false, loaded:true, errorOccurred:false, errorMessage:''});

        }, 
		error => {
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
            return (<ClaspEdit model={this.state.model} />);
        } 
		else {
		  return null;
		}
    }
}

/*<Codenesium>
    <Hash>d166425948b7cc2ff60f4e89a76b87f7</Hash>
</Codenesium>*/