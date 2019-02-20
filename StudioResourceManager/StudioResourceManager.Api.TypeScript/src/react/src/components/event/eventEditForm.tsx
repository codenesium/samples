import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { CreateResponse } from '../../api/apiObjects';
import { LoadingForm } from '../../lib/components/loadingForm';
import { ErrorForm } from '../../lib/components/errorForm';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import EventMapper from './eventMapper';
import EventViewModel from './eventViewModel';
import { Form, Input, Button, Checkbox, InputNumber, DatePicker} from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import { Alert } from 'antd';

interface EventEditComponentProps {
  form:WrappedFormUtils;
  history:any;
  match:any;
}

interface EventEditComponentState {
  model?: EventViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  submitted:boolean;
}

class EventEditComponent extends React.Component<
  EventEditComponentProps,
  EventEditComponentState
> {
  state = {
    model: new EventViewModel(),
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
          ApiRoutes.Events +
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
          let response = resp.data as Api.EventClientResponseModel;

          console.log(response);

          let mapper = new EventMapper();

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
        let model = values as EventViewModel;
        console.log('Received values of form: ', model);
        this.submit(model);
      }
    });
  };

  submit = (model:EventViewModel) =>
  {  
    let mapper = new EventMapper();
     axios
      .put(
        Constants.ApiEndpoint + ApiRoutes.Events + '/' + this.state.model!.id,
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
            Api.EventClientRequestModel
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
      return <LoadingForm />;
    } 
    else if (this.state.loaded) {

        return ( 
         <Form onSubmit={this.handleSubmit}>
            			<Form.Item>
              <label htmlFor='actualEndDate'>Actual End Date</label>
              <br />             
{getFieldDecorator('actualEndDate', {
              rules:[],
              })
              ( <DatePicker placeholder={"Actual End Date"} id={"actualEndDate"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='actualStartDate'>Actual Start Date</label>
              <br />             
{getFieldDecorator('actualStartDate', {
              rules:[],
              })
              ( <DatePicker placeholder={"Actual Start Date"} id={"actualStartDate"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='billAmount'>Bill Amount</label>
              <br />             
{getFieldDecorator('billAmount', {
              rules:[],
              })
              ( <InputNumber placeholder={"Bill Amount"} id={"billAmount"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='eventStatusId'>status</label>
              <br />             
{getFieldDecorator('eventStatusId', {
              rules:[],
              })
              ( <InputNumber placeholder={"status"} id={"eventStatusId"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='scheduledEndDate'>Scheduled End Date</label>
              <br />             
{getFieldDecorator('scheduledEndDate', {
              rules:[],
              })
              ( <DatePicker placeholder={"Scheduled End Date"} id={"scheduledEndDate"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='scheduledStartDate'>Scheduled Start Date</label>
              <br />             
{getFieldDecorator('scheduledStartDate', {
              rules:[],
              })
              ( <DatePicker placeholder={"Scheduled Start Date"} id={"scheduledStartDate"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='studentNote'>Student Notes</label>
              <br />             
{getFieldDecorator('studentNote', {
              rules:[],
              })
              ( <Input placeholder={"Student Notes"} id={"studentNote"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='teacherNote'>Teacher notes</label>
              <br />             
{getFieldDecorator('teacherNote', {
              rules:[],
              })
              ( <Input placeholder={"Teacher notes"} id={"teacherNote"} /> )}
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

export const WrappedEventEditComponent = Form.create({ name: 'Event Edit' })(EventEditComponent);

/*<Codenesium>
    <Hash>ccd19bd78d6d26705bcb2437ba0abd22</Hash>
</Codenesium>*/