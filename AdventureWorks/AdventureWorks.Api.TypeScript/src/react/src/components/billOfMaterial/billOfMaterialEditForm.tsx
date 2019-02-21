import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { CreateResponse } from '../../api/apiObjects';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import BillOfMaterialMapper from './billOfMaterialMapper';
import BillOfMaterialViewModel from './billOfMaterialViewModel';
import { Form, Input, Button, Switch, InputNumber, DatePicker, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';

interface BillOfMaterialEditComponentProps {
  form:WrappedFormUtils;
  history:any;
  match:any;
}

interface BillOfMaterialEditComponentState {
  model?: BillOfMaterialViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  submitted:boolean;
}

class BillOfMaterialEditComponent extends React.Component<
  BillOfMaterialEditComponentProps,
  BillOfMaterialEditComponentState
> {
  state = {
    model: new BillOfMaterialViewModel(),
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
	submitted:false
  };

    componentDidMount() {
    this.setState({ ...this.state, loading: true });

    axios
      .get(
        Constants.ApiEndpoint +
          ApiRoutes.BillOfMaterials +
          '/' +
          this.props.match.params.id,
        {
          headers: {
            'Content-Type': 'application/json',
          },
        }
      )
      .then(
        resp => {
          let response = resp.data as Api.BillOfMaterialClientResponseModel;

          console.log(response);

          let mapper = new BillOfMaterialMapper();

          this.setState({
            model: mapper.mapApiResponseToViewModel(response),
            loading: false,
            loaded: true,
            errorOccurred: false,
            errorMessage: '',
          });

		  this.props.form.setFieldsValue(mapper.mapApiResponseToViewModel(response));
        },
        error => {
          console.log(error);
          this.setState({
            model: undefined,
            loading: false,
            loaded: false,
            errorOccurred: true,
            errorMessage: 'Error from API',
          });
        }
      );
 }
 
 handleSubmit = (e:FormEvent<HTMLFormElement>) => {
     e.preventDefault();
     this.props.form.validateFields((err:any, values:any) => {
      if (!err) {
        let model = values as BillOfMaterialViewModel;
        console.log('Received values of form: ', model);
        this.submit(model);
      }
    });
  };

  submit = (model:BillOfMaterialViewModel) =>
  {  
    let mapper = new BillOfMaterialMapper();
     axios
      .put(
        Constants.ApiEndpoint + ApiRoutes.BillOfMaterials + '/' + this.state.model!.billOfMaterialsID,
        mapper.mapViewModelToApiRequest(model),
        {
          headers: {
            'Content-Type': 'application/json',
          },
        }
      )
      .then(
        resp => {
          let response = resp.data as CreateResponse<
            Api.BillOfMaterialClientRequestModel
          >;
          this.setState({...this.state, submitted:true, model:mapper.mapApiResponseToViewModel(response.record!), errorOccurred:false, errorMessage:''});
          console.log(response);
        },
        error => {
          console.log(error);
          this.setState({...this.state, submitted:true, errorOccurred:true, errorMessage:'Error from API'});
        }
      ); 
  }
  
  render() {

    const { getFieldDecorator, getFieldsError, getFieldError, isFieldTouched } = this.props.form;
        
    let message:JSX.Element = <div></div>;
    if(this.state.submitted)
    {
      if (this.state.errorOccurred) {
        message = <Alert message={this.state.errorMessage} type='error' />;
      }
      else
      {
        message = <Alert message='Submitted' type='success' />;
      }
    }

    if (this.state.loading) {
      return <Spin size="large" />;
    } 
    else if (this.state.loaded) {

        return ( 
         <Form onSubmit={this.handleSubmit}>
            			<Form.Item>
              <label htmlFor='bOMLevel'>BOMLevel</label>
              <br />             
              {getFieldDecorator('bOMLevel', {
              rules:[],
              
              })
              ( <DatePicker format={'YYYY-MM-DD'} placeholder={"BOMLevel"} id={"bOMLevel"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='componentID'>ComponentID</label>
              <br />             
              {getFieldDecorator('componentID', {
              rules:[],
              
              })
              ( <DatePicker format={'YYYY-MM-DD'} placeholder={"ComponentID"} id={"componentID"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='endDate'>EndDate</label>
              <br />             
              {getFieldDecorator('endDate', {
              rules:[],
              
              })
              ( <DatePicker format={'YYYY-MM-DD'} placeholder={"EndDate"} id={"endDate"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='modifiedDate'>ModifiedDate</label>
              <br />             
              {getFieldDecorator('modifiedDate', {
              rules:[],
              
              })
              ( <DatePicker format={'YYYY-MM-DD'} placeholder={"ModifiedDate"} id={"modifiedDate"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='perAssemblyQty'>PerAssemblyQty</label>
              <br />             
              {getFieldDecorator('perAssemblyQty', {
              rules:[],
              
              })
              ( <DatePicker format={'YYYY-MM-DD'} placeholder={"PerAssemblyQty"} id={"perAssemblyQty"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='productAssemblyID'>ProductAssemblyID</label>
              <br />             
              {getFieldDecorator('productAssemblyID', {
              rules:[],
              
              })
              ( <DatePicker format={'YYYY-MM-DD'} placeholder={"ProductAssemblyID"} id={"productAssemblyID"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='startDate'>StartDate</label>
              <br />             
              {getFieldDecorator('startDate', {
              rules:[],
              
              })
              ( <DatePicker format={'YYYY-MM-DD'} placeholder={"StartDate"} id={"startDate"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='unitMeasureCode'>UnitMeasureCode</label>
              <br />             
              {getFieldDecorator('unitMeasureCode', {
              rules:[],
              
              })
              ( <DatePicker format={'YYYY-MM-DD'} placeholder={"UnitMeasureCode"} id={"unitMeasureCode"} /> )}
              </Form.Item>

			
          <Form.Item>
            <Button type="primary" htmlType="submit">
                Submit
              </Button>
            </Form.Item>
			{message}
        </Form>);
    } else {
      return null;
    }
  }
}

export const WrappedBillOfMaterialEditComponent = Form.create({ name: 'BillOfMaterial Edit' })(BillOfMaterialEditComponent);

/*<Codenesium>
    <Hash>4e33d76483b4e7a203d27aefbc62b0d5</Hash>
</Codenesium>*/