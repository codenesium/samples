import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { ActionResponse, CreateResponse } from '../../api/apiObjects';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import PetMapper from './petMapper';
import PetViewModel from './petViewModel';
import { Form, Input, Button, Switch, InputNumber, DatePicker, Spin, Alert, TimePicker } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import { ToLowerCaseFirstLetter } from '../../lib/stringUtilities';
import { BreedSelectComponent } from '../shared/breedSelect'
	import { PenSelectComponent } from '../shared/penSelect'
	interface PetEditComponentProps {
  form:WrappedFormUtils;
  history:any;
  match:any;
}

interface PetEditComponentState {
  model?: PetViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  submitted:boolean;
}

class PetEditComponent extends React.Component<
  PetEditComponentProps,
  PetEditComponentState
> {
  state = {
    model: new PetViewModel(),
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
          ApiRoutes.Pets +
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
          let response = resp.data as Api.PetClientResponseModel;

          console.log(response);

          let mapper = new PetMapper();

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
        let model = values as PetViewModel;
        console.log('Received values of form: ', model);
        this.submit(model);
      }
    });
  };

  submit = (model:PetViewModel) =>
  {  
    let mapper = new PetMapper();
     axios
      .put(
        Constants.ApiEndpoint + ApiRoutes.Pets + '/' + this.state.model!.id,
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
            Api.PetClientRequestModel
          >;
          this.setState({...this.state, submitted:true, model:mapper.mapApiResponseToViewModel(response.record!), errorOccurred:false, errorMessage:''});
          console.log(response);
        },
        error => {
          console.log(error);
		  let errorResponse = error.response.data as ActionResponse; 
		  if(error.response.data)
          {
			  errorResponse.validationErrors.forEach(x =>
			  {
				this.props.form.setFields({
				 [ToLowerCaseFirstLetter(x.propertyName)]: {
				  value:this.props.form.getFieldValue(ToLowerCaseFirstLetter(x.propertyName)),
				  errors: [new Error(x.errorMessage)]
				},
				})
			  });
		  }
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
              <label htmlFor='acquiredDate'>acquiredDate</label>
              <br />             
              {getFieldDecorator('acquiredDate', {
              rules:[{ required: true, message: 'Required' },
],
              
              })
              ( <DatePicker format={'YYYY-MM-DD'} placeholder={"acquiredDate"} /> )}
              </Form.Item>

						
                        <Form.Item>
                        <label htmlFor='breedId'>breedId</label>
                        <br />   
                        <BreedSelectComponent   
                          apiRoute={
                          Constants.ApiEndpoint +
                          ApiRoutes.Breeds}
                          getFieldDecorator={this.props.form.getFieldDecorator}
                          propertyName="breedId"
                          required={true}
                          selectedValue={this.state.model!.breedId}
                         />
                        </Form.Item>

						<Form.Item>
              <label htmlFor='description'>description</label>
              <br />             
              {getFieldDecorator('description', {
              rules:[{ required: true, message: 'Required' },
],
              
              })
              ( <Input placeholder={"description"} /> )}
              </Form.Item>

						
                        <Form.Item>
                        <label htmlFor='penId'>penId</label>
                        <br />   
                        <PenSelectComponent   
                          apiRoute={
                          Constants.ApiEndpoint +
                          ApiRoutes.Pens}
                          getFieldDecorator={this.props.form.getFieldDecorator}
                          propertyName="penId"
                          required={true}
                          selectedValue={this.state.model!.penId}
                         />
                        </Form.Item>

						<Form.Item>
              <label htmlFor='price'>price</label>
              <br />             
              {getFieldDecorator('price', {
              rules:[{ required: true, message: 'Required' },
],
              
              })
              ( <Input placeholder={"price"} /> )}
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

export const WrappedPetEditComponent = Form.create({ name: 'Pet Edit' })(PetEditComponent);

/*<Codenesium>
    <Hash>12de1c35e26c2e08bc52e77c93ce95c7</Hash>
</Codenesium>*/