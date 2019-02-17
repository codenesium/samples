import React, { Component } from 'react';
import axios from 'axios';
import * as Api from '../../api/models';
import { UpdateResponse } from '../../api/apiObjects'
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import { FormikProps,FormikErrors, Field, withFormik } from 'formik';
import { LoadingForm } from '../../lib/components/loadingForm'
import { ErrorForm } from '../../lib/components/errorForm'
import WorkOrderViewModel from './workOrderViewModel';
import WorkOrderMapper from './workOrderMapper';

interface Props {
    model?:WorkOrderViewModel
}

  const WorkOrderEditDisplay = (props: FormikProps<WorkOrderViewModel>) => {

   let status = props.status as UpdateResponse<Api.WorkOrderClientRequestModel>;
   
   let errorsForField = (name:string) : string =>
   { 
        let response = '';
        if(props.touched[name as keyof WorkOrderViewModel]  && props.errors[name as keyof WorkOrderViewModel]) {
            response += props.errors[name as keyof WorkOrderViewModel];
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
                        <label htmlFor="name" className={errorExistForField("dueDate") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>DueDate</label>
					    <div className="col-sm-12">
                             <Field type="datetime-local" name="dueDate" className={errorExistForField("dueDate") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("dueDate") && <small className="text-danger">{errorsForField("dueDate")}</small>}
                        </div>
                    </div>
							<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("endDate") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>EndDate</label>
					    <div className="col-sm-12">
                             <Field type="datetime-local" name="endDate" className={errorExistForField("endDate") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("endDate") && <small className="text-danger">{errorsForField("endDate")}</small>}
                        </div>
                    </div>
							<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("modifiedDate") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>ModifiedDate</label>
					    <div className="col-sm-12">
                             <Field type="datetime-local" name="modifiedDate" className={errorExistForField("modifiedDate") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("modifiedDate") && <small className="text-danger">{errorsForField("modifiedDate")}</small>}
                        </div>
                    </div>
							<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("orderQty") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>OrderQty</label>
					    <div className="col-sm-12">
                             <Field type="datetime-local" name="orderQty" className={errorExistForField("orderQty") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("orderQty") && <small className="text-danger">{errorsForField("orderQty")}</small>}
                        </div>
                    </div>
							<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("productID") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>ProductID</label>
					    <div className="col-sm-12">
                             <Field type="datetime-local" name="productID" className={errorExistForField("productID") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("productID") && <small className="text-danger">{errorsForField("productID")}</small>}
                        </div>
                    </div>
							<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("scrappedQty") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>ScrappedQty</label>
					    <div className="col-sm-12">
                             <Field type="datetime-local" name="scrappedQty" className={errorExistForField("scrappedQty") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("scrappedQty") && <small className="text-danger">{errorsForField("scrappedQty")}</small>}
                        </div>
                    </div>
							<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("scrapReasonID") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>ScrapReasonID</label>
					    <div className="col-sm-12">
                             <Field type="datetime-local" name="scrapReasonID" className={errorExistForField("scrapReasonID") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("scrapReasonID") && <small className="text-danger">{errorsForField("scrapReasonID")}</small>}
                        </div>
                    </div>
							<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("startDate") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>StartDate</label>
					    <div className="col-sm-12">
                             <Field type="datetime-local" name="startDate" className={errorExistForField("startDate") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("startDate") && <small className="text-danger">{errorsForField("startDate")}</small>}
                        </div>
                    </div>
							<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("stockedQty") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>StockedQty</label>
					    <div className="col-sm-12">
                             <Field type="datetime-local" name="stockedQty" className={errorExistForField("stockedQty") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("stockedQty") && <small className="text-danger">{errorsForField("stockedQty")}</small>}
                        </div>
                    </div>
							<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("workOrderID") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>WorkOrderID</label>
					    <div className="col-sm-12">
                             <Field type="datetime-local" name="workOrderID" className={errorExistForField("workOrderID") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("workOrderID") && <small className="text-danger">{errorsForField("workOrderID")}</small>}
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


const WorkOrderEdit = withFormik<Props, WorkOrderViewModel>({
    mapPropsToValues: props => {
        let response = new WorkOrderViewModel();
		response.setProperties(props.model!.dueDate,props.model!.endDate,props.model!.modifiedDate,props.model!.orderQty,props.model!.productID,props.model!.scrappedQty,props.model!.scrapReasonID,props.model!.startDate,props.model!.stockedQty,props.model!.workOrderID);	
		return response;
      },
  
    // Custom sync validation
    validate: values => {
      let errors:FormikErrors<WorkOrderViewModel> = { };

	  if(values.dueDate == undefined) {
                errors.dueDate = "Required"
                    }if(values.modifiedDate == undefined) {
                errors.modifiedDate = "Required"
                    }if(values.orderQty == 0) {
                errors.orderQty = "Required"
                    }if(values.productID == 0) {
                errors.productID = "Required"
                    }if(values.scrappedQty == 0) {
                errors.scrappedQty = "Required"
                    }if(values.startDate == undefined) {
                errors.startDate = "Required"
                    }if(values.stockedQty == 0) {
                errors.stockedQty = "Required"
                    }if(values.workOrderID == 0) {
                errors.workOrderID = "Required"
                    }

      return errors;
    },
    handleSubmit: (values, actions) => {
        actions.setStatus(undefined);
		  
	    let mapper = new WorkOrderMapper();

        axios.put(Constants.ApiEndpoint + ApiRoutes.WorkOrders +'/' + values.workOrderID,
           
	    mapper.mapViewModelToApiRequest(values),
        {
            headers: {
                'Content-Type': 'application/json',
            }
        })
        .then(resp => {
            let response = resp.data as UpdateResponse<Api.WorkOrderClientRequestModel>;
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
  
    displayName: 'WorkOrderEdit', 
  })(WorkOrderEditDisplay);

 
  interface IParams 
  {
     workOrderID:number;
  }

  interface IMatch
  {
     params: IParams;
  }
  
  interface WorkOrderEditComponentProps
  {
     match:IMatch;
  }

  interface WorkOrderEditComponentState
  {
      model?:WorkOrderViewModel;
      loading:boolean;
      loaded:boolean;
      errorOccurred:boolean;
      errorMessage:string;
  }

  export default class WorkOrderEditComponent extends React.Component<WorkOrderEditComponentProps, WorkOrderEditComponentState> {

    state = ({model:undefined, loading:false, loaded:false, errorOccurred:false, errorMessage:''});

    componentDidMount () {
        this.setState({...this.state,loading:true});

        axios.get(Constants.ApiEndpoint + ApiRoutes.WorkOrders + '/' + this.props.match.params.workOrderID, {
            headers: {
                'Content-Type': 'application/json',
            }
        })
        .then(resp => {
            let response = resp.data as Api.WorkOrderClientResponseModel;
            
            console.log(response);

			let mapper = new WorkOrderMapper();

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
            return (<WorkOrderEdit model={this.state.model} />);
        } 
		else {
		  return null;
		}
    }
}

/*<Codenesium>
    <Hash>515c019d916c1b88d6573a7b16eba1f9</Hash>
</Codenesium>*/