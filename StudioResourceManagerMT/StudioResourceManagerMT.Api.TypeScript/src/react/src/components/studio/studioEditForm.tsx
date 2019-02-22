import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { CreateResponse } from '../../api/apiObjects';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import StudioMapper from './studioMapper';
import StudioViewModel from './studioViewModel';
import { Form, Input, Button, Switch, InputNumber, DatePicker, Spin, Alert, TimePicker } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';

interface StudioEditComponentProps {
  form:WrappedFormUtils;
  history:any;
  match:any;
}

interface StudioEditComponentState {
  model?: StudioViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  submitted:boolean;
}

class StudioEditComponent extends React.Component<
  StudioEditComponentProps,
  StudioEditComponentState
> {
  state = {
    model: new StudioViewModel(),
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
          ApiRoutes.Studios +
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
          let response = resp.data as Api.StudioClientResponseModel;

          console.log(response);

          let mapper = new StudioMapper();

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
        let model = values as StudioViewModel;
        console.log('Received values of form: ', model);
        this.submit(model);
      }
    });
  };

  submit = (model:StudioViewModel) =>
  {  
    let mapper = new StudioMapper();
     axios
      .put(
        Constants.ApiEndpoint + ApiRoutes.Studios + '/' + this.state.model!.id,
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
            Api.StudioClientRequestModel
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
              <label htmlFor='address1'>address1</label>
              <br />             
              {getFieldDecorator('address1', {
              rules:[{ required: true, message: 'Required' },
{ whitespace: true, message: 'Required' },
{ max: 128, message: 'Exceeds max length of 128' },
],
              
              })
              ( <DatePicker format={'YYYY-MM-DD'} placeholder={"address1"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='address2'>address2</label>
              <br />             
              {getFieldDecorator('address2', {
              rules:[{ required: true, message: 'Required' },
{ whitespace: true, message: 'Required' },
{ max: 128, message: 'Exceeds max length of 128' },
],
              
              })
              ( <DatePicker format={'YYYY-MM-DD'} placeholder={"address2"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='city'>city</label>
              <br />             
              {getFieldDecorator('city', {
              rules:[{ required: true, message: 'Required' },
{ whitespace: true, message: 'Required' },
{ max: 128, message: 'Exceeds max length of 128' },
],
              
              })
              ( <DatePicker format={'YYYY-MM-DD'} placeholder={"city"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='name'>name</label>
              <br />             
              {getFieldDecorator('name', {
              rules:[{ required: true, message: 'Required' },
{ whitespace: true, message: 'Required' },
{ max: 128, message: 'Exceeds max length of 128' },
],
              
              })
              ( <DatePicker format={'YYYY-MM-DD'} placeholder={"name"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='province'>province</label>
              <br />             
              {getFieldDecorator('province', {
              rules:[{ required: true, message: 'Required' },
{ whitespace: true, message: 'Required' },
{ max: 90, message: 'Exceeds max length of 90' },
],
              
              })
              ( <DatePicker format={'YYYY-MM-DD'} placeholder={"province"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='website'>website</label>
              <br />             
              {getFieldDecorator('website', {
              rules:[{ required: true, message: 'Required' },
{ whitespace: true, message: 'Required' },
{ max: 128, message: 'Exceeds max length of 128' },
],
              
              })
              ( <DatePicker format={'YYYY-MM-DD'} placeholder={"website"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='zip'>zip</label>
              <br />             
              {getFieldDecorator('zip', {
              rules:[{ max: 128, message: 'Exceeds max length of 128' },
],
              
              })
              ( <DatePicker format={'YYYY-MM-DD'} placeholder={"zip"} /> )}
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

export const WrappedStudioEditComponent = Form.create({ name: 'Studio Edit' })(StudioEditComponent);

/*<Codenesium>
    <Hash>ea4e8a5b2956aea9bbe606d5c705298c</Hash>
</Codenesium>*/